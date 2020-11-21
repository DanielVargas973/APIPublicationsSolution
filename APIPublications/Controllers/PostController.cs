using APIPublications.Class.Utilities;
using APIPublications.Core.Core;
using APIPublications.Model.request;
using APIPublications.Model.response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace APIPublications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UtilitiesAPI utilitiesAPI;

        public PostController(IConfiguration configuration)
        {
            utilitiesAPI = new UtilitiesAPI(configuration);
        }

        [HttpPost("new")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<bool> NewPost(PublicationRequestModel publicationRequestModel)
        {
            PostCore postCore = new PostCore(utilitiesAPI.GetDatabaseConnection("DBMyPosts"));
            return postCore.NewPost(publicationRequestModel);
        }

        [HttpGet("list/{idUser}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<PublicationResponseModel>> ListPost(int idUser)
        {
            PostCore postCore = new PostCore(utilitiesAPI.GetDatabaseConnection("DBMyPosts"));
            return postCore.ListPostOfAnUser(idUser);
        }
        [HttpDelete("delete/{idPost}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<bool> DeletePost(int idPost)
        {
            PostCore postCore = new PostCore(utilitiesAPI.GetDatabaseConnection("DBMyPosts"));
            return postCore.DeletePost(idPost);
        }
    }
}