/*
 * This controller was supposed to be implemented and will be the next course of action for this project.
 */
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ISearchHistoryDataService = WebApplication.DataInterfaces.ISearchHistoryDataService;

#nullable enable

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/history")]
    public class SearchHistoryController : Controller
    {
        private readonly ISearchHistoryDataService _iDataServices;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public SearchHistoryController(ISearchHistoryDataService dataServices, IMapper mapper,
            IConfiguration configuration)
        {
            _iDataServices = dataServices;
            _mapper = mapper;
            _config = configuration;
        }

        //Search History
        [HttpGet("historySearch/{userid}")]
        public IActionResult GetAllSearchHistoryFromOneUser(string? userid)
        {
            var searchHistoryUser = _iDataServices.GetAllSearchHistoryFromOneUser(userid);
            return Ok(searchHistoryUser);
        }

        [HttpPost("postSearchHistory")]
        public IActionResult PostNewSearchHistory(string searchtext, int userid)
        {
            var newSearchHistory = _iDataServices.PostNewSearchHistory(searchtext, userid);
            return Ok(newSearchHistory);
        }
    }
}