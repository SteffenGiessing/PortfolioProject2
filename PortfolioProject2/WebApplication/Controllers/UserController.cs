using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/user")]
    
        public class UserController : Controller
        {
            private readonly IUserDataService _iDataServices;

            public UserController(IUserDataService dataServices)
            {
                _iDataServices = dataServices;
            }
            
            [HttpGet]
            public ActionResult<IEnumerable<User_Comments>> GetAllComments()
            {
                var comments = _iDataServices.GetAllComments();
                return Ok(comments);
            }

        [HttpGet("userComment/{userid}")]
        public ActionResult<User_Comments> GetAllCommentsFromOneUser(string? userid)
        {
            var allCommentsFromOneUser = _iDataServices.GetAllCommentsFromOneUser(userid).Result;
            return Ok(allCommentsFromOneUser);
        }

        [HttpGet("movieComment/{titleid}")]
        public async Task<ActionResult<User_Comments>> GetAllCommentsFromOneTitle(string? titleid)
        {
            var allCommentsFromOneTitle = _iDataServices.GetAllCommentsFromOneTitle(titleid).Result;
            return Ok(allCommentsFromOneTitle);
        }
    }
}


