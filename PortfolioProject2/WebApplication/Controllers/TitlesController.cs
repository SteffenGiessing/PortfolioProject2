#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitlesController : Controller
    {
        private readonly IDataServices _iDataServices;

        public TitlesController(IDataServices dataServices)
        {
            _iDataServices = dataServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Titles>> GetTitles()
        {
            var titles = _iDataServices.getAllTitles();
            return Ok(titles);
        }

        [HttpGet("{titleId?}")]
        public ActionResult<Titles> getTitleById(string? titleId)
        {
            var titles = _iDataServices.getTitleById(titleId);
            return Ok(titles);
        }
        
        
        
    }
}