using APIPublications.Class.Utilities;
using APIPublications.Core.Core;
using APIPublications.Model.request;
using APIPublications.Model.response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIPublications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UtilitiesAPI utilitiesAPI;

        public UserController(IConfiguration configuration)
        {
            utilitiesAPI = new UtilitiesAPI(configuration);
        }

        [HttpPost("new")]
        public ActionResult<UserResponseModel> NewUser(UserRequestModel userRequestModel)
        {
            UserCore userCore = new UserCore(utilitiesAPI.GetDatabaseConnection("DBMyPosts"));
            return userCore.NewUser(userRequestModel);
        }

        [HttpPost("validate")]
        public ActionResult<UserResponseModel> ValidateUser(UserRequestModel userRequestModel)
        {
            UserCore userCore = new UserCore(utilitiesAPI.GetDatabaseConnection("DBMyPosts"));
            UserResponseModel userResponseModel = userCore.AuthenticateUser(userRequestModel);
            if (userResponseModel.Id > 0) BuildToken(userResponseModel);
            return userResponseModel;
        }

        private UserResponseModel BuildToken(UserResponseModel userResponseModel)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userResponseModel.Id.ToString()),
                new Claim("emailUser", userResponseModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(utilitiesAPI.GetEnvironmentVariable("secretKeyJwt")));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            DateTime expirationTime = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: utilitiesAPI.GetConfigurationAppSettings("appSettings:issuer"),
                audience: utilitiesAPI.GetConfigurationAppSettings("appSettings:audience"),
                claims: claims,
                expires: expirationTime,
                signingCredentials: signingCredentials);
            userResponseModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            userResponseModel.ExpiresIn = expirationTime;
            return userResponseModel;
        }
    }
}