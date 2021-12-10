using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DataInterfaces;
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

            // Get Comments
            [HttpGet]
            public ActionResult<IEnumerable<User_Comments>> GetAllComments()
            {
                var comments = _iDataServices.GetAllComments();
                return Ok(comments);
            }

            [HttpGet("{userid?}/comments")]
            public IActionResult GetUserComments(string userid,[FromHeader] TokenChecker getHeaders)
            {
                var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);

                var userComments = _iDataServices.GetUserComments(userid).Result;
                /*
                if (userComments == null)
                {
                    return NotFound();
                }
                */
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


