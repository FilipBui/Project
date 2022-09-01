using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SpearSharp.Database;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext data;
        private IConfiguration configuration;
        private IKingdomService kingdomService;

        public UserService(ApplicationDbContext data, IConfiguration configuration, IKingdomService kingdomService)
        {
            this.data = data;
            this.configuration = configuration;
            this.kingdomService = kingdomService;
        }

        public PlayerRegistrationDTO RegisterPlayer(PlayerRegistrationDTO player)
        {
            if (player.KingdomName is null)
            {
                player.KingdomName = $"{player.Username}'s kingdom";
            }
            data.Kingdoms.Add(new Kingdom()
            {
                KingdomName = player.KingdomName,
                Ruler = new Player(player.Username, player.Password, player.Email)
            });
            data.SaveChanges();
            return new PlayerRegistrationDTO(player.Username, kingdomService.GetKingdomIdByName(player.KingdomName));
        }

        public UserDTO CheckIfUserIsValid(UserDTO user)
        {
            var currentUser = data.Players.FirstOrDefault(p => p.Username.ToLower() ==
        user.UserName.ToLower() && p.Password == user.PassWord);
            UserDTO returnUser = new UserDTO(currentUser.Id, currentUser.Username, currentUser.Password, kingdomService.GetKingdomByUserName(currentUser));
            if (currentUser != null)
            {
                return returnUser;
            }
            return null;
        }

        public string CreateToken(UserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId",user.Id.ToString()),
                new Claim("Username", user.UserName),
                new Claim("KingdomId",user.Kingdom.Id.ToString()),
                new Claim("KingdomName",user.Kingdom.KingdomName)
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken GetClaimsPrincipal(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken.Replace("Bearer ", "")) as JwtSecurityToken;

            return jsonToken;
        }

        public LoginInfoDTO GetCurrentUser(string jwt)
        {
            if (jwt != null)
            {
                var userClaims = GetClaimsPrincipal(jwt.Replace("Bearer ", ""));

                return new LoginInfoDTO
                {
                    UserId = int.Parse(userClaims.Claims.FirstOrDefault(c => c.Type == "UserId").Value),
                    Username = userClaims.Claims.FirstOrDefault(c => c.Type == "Username").Value,
                    KingdomId = int.Parse(userClaims.Claims.FirstOrDefault(c => c.Type == "KingdomId").Value),
                    KingdomName = userClaims.Claims.FirstOrDefault(c => c.Type == "KingdomName").Value
                };
            }
            return null;
        }

        public bool IsUsernameTaken(PlayerRegistrationDTO player)
        {
            if (player.Username == null)
                return true;
            return data.Players.Any(p => p.Username.ToLower().Equals(player.Username.ToLower()));
        }

        public bool IsPasswordTooShort(PlayerRegistrationDTO player)
        {
            if (player.Password.Length < 8)
            {
                return true;
            }
            return false;
        }

    }
}