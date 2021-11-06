﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/omdb")]
    public class OmdbController : Controller
    {
        private readonly IOmdbDataService _iOmdbDataService;


        public OmdbController(IOmdbDataService dataService)
        {
            _iOmdbDataService = dataService;
        }

        [HttpGet("{omdbId}")]
        public async Task<ActionResult<Omdb_Data>> getOmdbDataById(string omdbId)
        {
            var omdb = _iOmdbDataService.GetOmdbById(omdbId).Result;
            return Ok(omdbId);
        }
    }
}