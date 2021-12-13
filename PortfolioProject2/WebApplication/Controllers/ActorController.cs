﻿#nullable enable
using System;
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

        [HttpGet("namesearch/{namessearch}")]
        public async Task<ActionResult<NameSearch>> getActorByName(string namessearch)
        {
            Console.WriteLine("HERE" + namessearch);
            var actorName = _iDataServices.GetBestMatchPersonName(namessearch).Result;
            return Ok(actorName);
        }
        
        [HttpGet("{titleId}")]
        public async Task<ActionResult<Actors_In_Title>> getActorsInTitle(string? titleId)
        {
            var actor = _iDataServices.GetActorsInTitle(titleId).Result;
            return Ok(actor);
        }
    }
}