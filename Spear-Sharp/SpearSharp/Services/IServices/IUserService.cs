using System;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
    public interface IUserService
    {
        UserDTO CheckIfUserIsValid(UserDTO user);
        string CreateToken(UserDTO user);
        LoginInfoDTO GetCurrentUser(string jwt);
        PlayerRegistrationDTO RegisterPlayer(PlayerRegistrationDTO player);
        bool IsUsernameTaken(PlayerRegistrationDTO player);
        bool IsPasswordTooShort(PlayerRegistrationDTO player);
    }
}