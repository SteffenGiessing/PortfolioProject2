/*
 * This controller is responsible for allowing our users to rate movies.
 * The RatingByUser Controller is responsible for communication between our frontend and the "backend".
 */

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DMOs;
using WebApplication.DTOs;
using WebApplication.Token;
using WebApplication.DataInterfaces;


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
        /*
         * Used to let the users rate movies. 
         */
        [HttpPost("add/userrating/")]
        public IActionResult CreateTitleRating(User_Ratings userRating, [FromHeader] TokenChecker getHeaders)
        {
            var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);
            if (token == true)
            {
                var creatRating = _iDataServices.CreateTitleRating(userRating).Result;
                if (creatRating == null)
                {
                    return NotFound();
                }

                return Ok(creatRating);
            }

            return Unauthorized();
        }
        
        /*
         * Used to fetch rating for a specific movie.
         */
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Ratings>> getRatings(string id)
        {
            var ratings = _iDataServices.GetRatingBy(id).Result;
            return Ok(ratings);
        }
    }
}