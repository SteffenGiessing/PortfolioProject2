#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitlesController : Controller
    {
        private readonly ITitlesDataService _iDataServices;

        public TitlesController(ITitlesDataService dataServices)
        {
            _iDataServices = dataServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Titles>> GetTitles()
        {
            var titles = _iDataServices.GetAllTitles();
            return Ok(titles);
        }

        [HttpGet("{titleId?}")]
        public async Task<ActionResult<Titles>> getTitleById(string? titleId)
        {
            var titles =  _iDataServices.GetTitleById(titleId).Result;
            return Ok(titles);
        }
        
        [HttpGet("result/{titleName}")]
        public async Task<ActionResult<Titles>> getTitleByName(string? titleName)
        {
            var nameTitles =  _iDataServices.GetTitleByName(titleName).Result;
            return Ok(nameTitles);
        }
    }
}