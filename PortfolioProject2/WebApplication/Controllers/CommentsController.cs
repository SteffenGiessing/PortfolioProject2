/*
 * Users in our system shall be able to comment on movies these comments will be stored
 * so the system users always can see what they have commented on
 * The Comments Controller is responsible for communication between our frontend and the "backend".
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DMOs;
using WebApplication.DTOs;
using WebApplication.Token;
using ICommentsDataService = WebApplication.DataInterfaces.ICommentsDataService;
#nullable enable
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ICommentsDataService _iDataServices;

        public CommentsController(ICommentsDataService dataServices, IConfiguration configuration)
        {
            _iDataServices = dataServices;
            _config = configuration;
        }

        /*
         * Getting All the comments that have been created by all users.
         */
        [HttpGet]
        public ActionResult<IEnumerable<User_Comments>> GetAllComments()
        {
            var comments = _iDataServices.GetAllComments();
            return Ok(comments);
        }

        /*
         * Getting a specific users comments.
         */
        [HttpGet("{userid}/comments")]
        public IActionResult GetUserComments(int userid, [FromHeader] TokenChecker getHeaders)
        {
            var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);
            if (token == true)
            {
                var userComments = _iDataServices.GetUserComments(userid).Result;

                if (userComments == null)
                {
                    return NotFound();
                }

                return Ok(userComments);
            }

            return Unauthorized();
        }
        
        /*
         * Getting all comments that have been made to a specific movie. 
         */
        [HttpGet("{titleid}")]
        public IActionResult GetCommentsFromTitle(string? titleid)
        {
            var allCommentsFromOneTitle = _iDataServices.GetCommentsFromTitle(titleid);
            return Ok(allCommentsFromOneTitle);
        }


        /*
         * Letting a user comment on one specific movie. 
         */
        [HttpPost("add/usercomment/")]
        public IActionResult CreateTitleComments(User_Comments userComments, [FromHeader] TokenChecker getHeaders)
        {
            var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);
            if (token == true)
            {
                var createComment = _iDataServices.CreateTitleComments(userComments).Result;
                if (createComment == null)
                {
                    return NotFound();
                }

                return Ok(createComment);
            }

            return Unauthorized();
        }
    }
}