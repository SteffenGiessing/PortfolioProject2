using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;
using WebApplication.DTOs;
using WebApplication.Token;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingByUserController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IRatingByUserDataService _iDataServices;

        public RatingByUserController(IRatingByUserDataService dataServices, IConfiguration configuration)
        {
            _iDataServices = dataServices;
            _config = configuration;
        }

        [HttpPost("add/userrating/")]
        public IActionResult CreateTitleRating(User_Ratings userRating, [FromHeader] TokenChecker getHeaders)
        {
            var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);
            if (token)
            {
                var creatRating = _iDataServices.CreateTitleRating(userRating).Result;
                if (creatRating == null) return NotFound();
                return Ok(creatRating);
            }

            return Unauthorized();
        }
    }
}