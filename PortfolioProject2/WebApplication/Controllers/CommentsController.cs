using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DataInterfaces;
using IUserDataService = WebApplication.DataInterfaces.IUserDataService;
#nullable enable
using System.Collections.Generic;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/comments")]
    
        public class CommentsController : Controller
        {
            private readonly ICommentsDataService _iDataServices;
            private readonly IMapper _mapper;
            private readonly IConfiguration _config;

            public CommentsController(ICommentsDataService dataServices, IMapper mapper, IConfiguration configuration)
            {
                _iDataServices = dataServices;
                _mapper = mapper;
                _config = configuration;
            }

            // Get Comments
            [HttpGet]
            public ActionResult<IEnumerable<User_Comments>> GetAllComments()
            {
                var comments = _iDataServices.GetAllComments();
                return Ok(comments);
            }

            [HttpGet("{userid}/allcomments")]
            public IActionResult GetUserComments(int userid)
            {
                var userComments = _iDataServices.GetUserComments(userid);
                if (userComments == null)
                {
                    return NotFound();
                }

                return Ok(userComments);
            }

            [HttpGet("{titleid}")]
            public IActionResult GetCommentsFromTitle(string? titleid)
            {
                var allCommentsFromOneTitle = _iDataServices.GetCommentsFromTitle(titleid);
                return Ok(allCommentsFromOneTitle);
            }
            
            
            // Get Post Comments
            [HttpPost("{userid}/usercomment/{titleid}")]
            
            public IActionResult CreateTitleComments(int userid, string titleid, string commenttext)
            {
                var createComment = _iDataServices.CreateTitleComments(userid, titleid, commenttext);
                return Ok(createComment);
            }
        }
}


