#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/actor")]
    public class ActorController : Controller
    {
        private readonly IActorDataService _iDataServices;

        public ActorController(IActorDataService dataServices)
        {
            _iDataServices = dataServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person_Info>> GetActors()
        {
            var actor = _iDataServices.GetAllActors();
            return Ok(actor);
        }
    }
}