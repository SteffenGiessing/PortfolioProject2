﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IUserDataService = WebApplication.DataInterfaces.IUserDataService;
#nullable enable
using System.Collections.Generic;
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
        }
}


