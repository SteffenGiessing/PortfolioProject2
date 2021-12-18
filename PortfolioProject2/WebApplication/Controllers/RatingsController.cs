using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingsController : Controller
    {
        private readonly IRatings _iratings;

        public RatingsController(IRatings dataServices)
        {
            _iratings = dataServices;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Ratings>> getRatings(string id)
        {
            var ratings = _iratings.GetRatingBy(id).Result;
            return Ok(ratings);
        }
    }
}