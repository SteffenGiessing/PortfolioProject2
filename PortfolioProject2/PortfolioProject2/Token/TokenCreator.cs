/*
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PortfolioProject2.Models.DMOs;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace PortfolioProject2.Token
{
    public static class TokenCreator
    {
        public static string TokenCreater(Users user, IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var getUser = new[]
            {
                new Claim("email", user.EmailAddress),
                new Claim("userid", user.UserId.ToString())
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                getUser,
                expires: DateTime.Now.AddMinutes(250),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
*/