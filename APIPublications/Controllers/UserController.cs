using APIPublications.Class.Utilities;
using APIPublications.Core.Core;
using APIPublications.Model.request;
using APIPublications.Model.response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            return userCore.AuthenticateUser(userRequestModel);
        }
    }
}