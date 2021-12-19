#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/personprofession/personpid")]
    public class ProfessionController : Controller
    {
        private readonly IActorDataService _iDataServices;

        public ProfessionController(IActorDataService dataServices)
        {
            _iDataServices = dataServices;
        }

        [HttpGet("{pid}")]
        public async Task<ActionResult<Person_Profession>> getPersonProfessionByActorId(string? pid)
        {
            var profession = _iDataServices.GetPersonProfessionByActorId(pid).Result;
            return Ok(profession);
        }
    }
}