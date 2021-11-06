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

        [HttpGet("{pid}")]
        public async Task<ActionResult<Person_Info>> getPersonKnownFor(string? pid)
        {
            var personKnownFor = _iDataServices.GetPersonKnownFor(pid).Result;
            return Ok(personKnownFor);
        }
        
        [HttpGet("result/{name}")]
        public async Task<ActionResult<Person_Info>> getActorsByName(string name)
        {
            var actorsName = _iDataServices.GetActorsByName(name).Result;
            return Ok(actorsName);
        }
        
        [HttpGet("info/{pid}")]
        public async Task<ActionResult<Person_Info>> getActorOnPid(string? pid)
        {
            var actorPid = _iDataServices.GetActorOnPid(pid).Result;
            return Ok(actorPid);
        }
    }
}