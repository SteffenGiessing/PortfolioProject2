using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;
using WebApplication.DTOs;
using WebApplication.Token;
using ICommentsDataService = WebApplication.DataInterfaces.ICommentsDataService;
#nullable enable
using System;
using System.Collections.Generic;
using PortfolioProject2.Models.DMOs;

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

            // Get Comments6
            [HttpGet]
            public ActionResult<IEnumerable<User_Comments>> GetAllComments()
            {
                var comments = _iDataServices.GetAllComments();
                return Ok(comments);
            }

            [HttpGet("{userid}/comments")]
            public IActionResult GetUserComments(int userid, [FromHeader] TokenChecker getHeaders)
            {
                //THIS STEP AUTHENTICATES THE FRONT END IT IS NEEDED EVERYTIME USER HAS TO INTERACT WITH THE SYSTEM
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

            [HttpGet("{titleid}")]
            public IActionResult GetCommentsFromTitle(string? titleid)
            {
                var allCommentsFromOneTitle = _iDataServices.GetCommentsFromTitle(titleid);
                return Ok(allCommentsFromOneTitle);
            }
            
            
            // Get Post Comments
            [HttpPost("{userid}/usercomment/{titleid}")]
            
            public IActionResult CreateTitleComments(int userId, string titleId, string commentText)
            {
                var createComment = _iDataServices.CreateTitleComments(userId, titleId, commentText);
                return Ok(createComment);
            }
        }
}


