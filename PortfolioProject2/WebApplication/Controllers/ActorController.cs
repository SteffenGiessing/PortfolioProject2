/*
 * The users shall be able to search and retrive different information regarding actors.
 * The Actor Controller is responsible for communication between our frontend and the "backend".
 */

#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

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

        /*
         * Get All Actors.
         */
        [HttpGet]
        public ActionResult<IEnumerable<Person_Info>> GetActors()
        {
            var actor = _iDataServices.GetAllActors();
            return Ok(actor);
        }

        /*
         * Get information about a specific Actor and what he is know for based upon the Pid.
         */
        [HttpGet("{pid}")]
        public async Task<ActionResult<Person_Info>> getPersonKnownFor(string? pid)
        {
            var personKnownFor = _iDataServices.GetPersonKnownFor(pid).Result;
            return Ok(personKnownFor);
        }

        /*
         * Get Actor with a specific name.
         */
        [HttpGet("result/{name}")]
        public async Task<ActionResult<Person_Info>> getActorsByName(string name)
        {
            var actorsName = _iDataServices.GetActorsByName(name).Result;
            return Ok(actorsName);
        }

        /*
         * Get information about a specific actor based upon the pid.
         */
        [HttpGet("info/{pid}")]
        public async Task<ActionResult<Person_Info>> getActorOnPid(string? pid)
        {
            var actorPid = _iDataServices.GetActorOnPid(pid).Result;
            return Ok(actorPid);
        }

        /*
         * Search all actors based on a named search will find all actor names matching,
         * the search criteria.
         */
        [HttpGet("namesearch/{namessearch}")]
        public async Task<ActionResult<NameSearch>> getActorByName(string namessearch)
        {
            Console.WriteLine("HERE" + namessearch);
            var actorName = _iDataServices.GetBestMatchPersonName(namessearch).Result;
            return Ok(actorName);
        }
    }
}