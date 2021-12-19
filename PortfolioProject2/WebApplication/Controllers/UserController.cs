/*
 * The User controller is responsible for everything regarding our users.
 * The User Controller is responsible for communication between our frontend and the "backend".
 */

using System;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DMOs;
using WebApplication.DTOs;
using IUserDataService = WebApplication.DataInterfaces.IUserDataService;
#nullable enable
using System.Collections.Generic;
using WebApplication.Token;


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
         * Creating the users for our system.
         */
        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult CreateUser(UserToCreateOrLogin user)
        {
            //Generating salt.
            byte[] getsalt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(getsalt);
            }

            //Creating hashed password.
            string getHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: getsalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            user.Password = getHash;
            user.PasswordSalt = getsalt;

            var mapUser = _mapper.Map<User_User>(user);

            var created = _iDataServices.CreateUser(mapUser).Result;
            if (created.FirstName == "null")
            {
                return NotFound("Inserted data isn't correct format.");
            }

            var token = TokenCreator.TokenCreater(created, _config);
            var userToReturn = _mapper.Map<User_User>(created);
            userToReturn.TokenJwt = token;

            return Ok(userToReturn);
        }

        /*
         * Used to login our already existing users.
         */
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LoginUser(UserToCreateOrLogin user)
        {
            //Fetching user based on email
            var getUser = _iDataServices.GetUserByEmail(user.EmailAddress).Result;

            if (getUser == null)
            {
                return NotFound();
            }

            //Using fetched information to regenerate hased password.
            string getHash = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: user.Password,
                    salt: getUser.PasswordSalt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
            // Validating if the password is correct.
            var validatedUser = _iDataServices.ValidatePassword(user.EmailAddress, getHash).Result;

            if (validatedUser == null)
            {
                return Unauthorized();
            }

            var token = TokenCreator.TokenCreater(validatedUser, _config);
            var userToReturn = _mapper.Map<User_User>(validatedUser);
            userToReturn.TokenJwt = token;
            return Ok(userToReturn);
        }

        /*
         * Fetching User based on email
         */
        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var getUserByEmail = _iDataServices.GetUserByEmail(email).Result;
            return Ok(getUserByEmail);
        }

        /*
         * Delete user.
         */
        [HttpDelete("deleteuser")]
        public IActionResult DeleteUser(User_User user)
        {
            var deleteUser = _iDataServices.DeleteUser(user).Result;
            return Ok();
        }

        /*
        * Update User.
        */
        [HttpPost("update")]
        public IActionResult UpdateUser(User_User user)
        {
            var updateUser = _iDataServices.UpdateUser(user).Result;
            return Ok(updateUser);
        }
    }
}