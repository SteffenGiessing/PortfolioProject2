/*
* Token Creater is for creating and validating together that are used when we are having communication between.
 * The front end and backend in our case we use it specifically while having user interactions.
*/

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication.DMOs;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace WebApplication.Token
{
    public static class TokenCreator
    {
        /*
         * Token Creator based on a user
         */
        public static string TokenCreater(User_User user, IConfiguration configuration)
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
        /*
         * Validating the token
         */
        public static bool ValidateToken(string authToken, IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Issuer"];
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(authToken, new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = key,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}