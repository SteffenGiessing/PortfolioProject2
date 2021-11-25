using System;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PortfolioProject2.Models.DataInterfaces;
//using PortfolioProject2.Token;
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
            private readonly IMapper _mapper;
            private readonly IConfiguration _config;

            public UserController(IUserDataService dataServices, IMapper mapper, IConfiguration configuration)
            {
                _iDataServices = dataServices;
                _mapper = mapper;
                _config = configuration;
            }
/*
            [AllowAnonymous]
            [HttpPost]
            public IActionResult CreateUser(UserToCreate user)
            {
                byte[] getsalt = new byte[128 / 8];
                var randomNum = RandomNumberGenerator.Create();
                randomNum.GetBytes(getsalt);

                string getHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: user.Password, salt: getsalt,
                    prf: KeyDerivationPrf.HMACSHA256, iterationCount: 10000, numBytesRequested: 256 / 8));

                user.Password = getHash;
                user.Salt = getsalt;

                var mapUser = _mapper.Map<Users>(user);
                
                var created = _iDataServices.CreateUser(mapUser);
                var token = TokenCreator.TokenCreater(created, _config);
                var userToStore = _mapper.Map<User_User>(created);
                userToStore.TokenJWT = token;


                return Created("", userToStore);
            }
            
            */
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


