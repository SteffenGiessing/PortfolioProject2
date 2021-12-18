using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.DataInterfaces;

#nullable enable

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/history")]
    public class SearchHistoryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ISearchHistoryDataService _iDataServices;
        private readonly IMapper _mapper;

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