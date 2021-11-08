using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Authentication;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortfolioProject2.Models.DataInterfaces;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserDataService _userDataService;
        private readonly IConfiguration _configuration;

        public UserController(IUserDataService iuserDataService, IConfiguration configuration)
        {
            _userDataService = iuserDataService;
            _configuration = configuration;
        }
        [HttpGet]
        
        [HttpGet]
        public IActionResult Register(User_User register)
        {
            
            int.TryParse(_configuration.GetSection("Auth:PasswordSize").Value, out int pwdSize);

            var salt = PasswordService.GenerateSalt(pwdSize);
          
            var pwd = PasswordService.HashPassword(register.PasswordHash, salt, pwdSize);

            _userDataService.CreateUser(register.FirstName, register.UserName, pwd, salt);

            return CreatedAtRoute(null, new { register.UserName});
        }
        
        
        [HttpPost]
        public IActionResult Login(User_User login)
        {
            var user = _userDataService.GetUser(login.UserName);
            if (user == null)
            {
                return BadRequest();
            }

            int.TryParse(_configuration.GetSection("Auth:PasswordSize").Value, out int pwdSize);

            if (pwdSize == 0)
            {
                throw new ArgumentException("No password size");
            }

            string secret = _configuration.GetSection("Auth:Secret").Value;
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentException("No secret");
            }

            var password = PasswordService.HashPassword(login.PasswordHash, login.PasswordSalt, pwdSize);

            if (password != login.PasswordHash)
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(secret);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new [] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddSeconds(45),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(securityToken);
            
            return Ok(new {login.UserName, token});
        }

    }
}