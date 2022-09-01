using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;
using SpearSharp.Services;

namespace SpearSharp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IKingdomService kingdomService;

        public AuthController(IUserService loginService, IKingdomService apiService)
        {
            this.userService = loginService;
            this.kingdomService = apiService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            UserDTO currentUser = userService.CheckIfUserIsValid(user);
            if (currentUser != null)
            {
                var token = userService.CreateToken(currentUser);
                return Ok(new LoginInfoDTO()
                {
                    Message = "Login was succesful",
                    UserId = currentUser.Id,
                    Username = currentUser.UserName,
                    KingdomId = currentUser.Kingdom.Id,
                    KingdomName = currentUser.Kingdom.KingdomName,
                    Token = token
                });
            }
            return BadRequest("Invalid UserName or Password");
        }

        [HttpGet("auth")]
        [Authorize]
        public IActionResult AuthorizePlayerIdentity([FromHeader] string authorization)
        {
            var currentUser = userService.GetCurrentUser(authorization);
            var response = new
            {
                UserId = currentUser.UserId,
                Username = currentUser.Username,
                Kingdom_Id = currentUser.KingdomId,
                Kingdom_Name = currentUser.KingdomName
            };

            return Json(response);
        }

        [HttpPost("registration")]
        public IActionResult PlayerRegistration([FromBody] PlayerRegistrationDTO player)
        {
            if (userService.IsPasswordTooShort(player))
            {
                var errorMessage = new { error = "Your password is too short" };
                return Json(errorMessage);
            }
            if (userService.IsUsernameTaken(player))
            {
                var errorMessage = new { error = "Either you have not entered your username or the username you have chosen is unfortunately taken" };
                return Json(errorMessage);
            }
            if (kingdomService.IsKingdomNameTaken(player))
            {
                var errorMessage = new { error = "The kingdom name you have chosen is unfortunately taken" };
                return Json(errorMessage);
            }
            PlayerRegistrationDTO registeredPlayer = userService.RegisterPlayer(player);
            var response = new
            {
                username = registeredPlayer.Username,
                kingdomId = registeredPlayer.KingdomId
            };
            return Json(response);
        }

        [HttpPut("registration")]
        public IActionResult CoordinatesRegistration(int kingdomId, int coordinateX, int coordinateY)
        {
            var outOfRangeMessage = new { error = "One or both coordinates are out of valid range (0-100)." };
            var coordinatesTakenMessage = new { error = "Given coordinates are already taken!" };
            if (coordinateX < 0 || coordinateY < 0 || coordinateX > 100 || coordinateY > 100)
            {
                return Json(outOfRangeMessage);
            }
            if (kingdomService.AreCoordinatesTaken(kingdomId, coordinateX, coordinateY))
            {
                return Json(coordinatesTakenMessage);
            }
            kingdomService.SetCoordinates(kingdomId, coordinateX, coordinateY);
            return Ok();
        }
    }
}