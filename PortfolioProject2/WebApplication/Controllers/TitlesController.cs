#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PortfolioProject2;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [ApiController]
        [Route("api/titles")]
    public class TitlesController : Controller
    {
        private readonly ITitlesDataService _iDataServices;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public TitlesController(ITitlesDataService dataServices, LinkGenerator linkGenerator, IMapper mapper)
        {
            _iDataServices = dataServices;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        /*[HttpGet]
        public ActionResult<IEnumerable<Titles>> GetTitles()
        {
            var titles = _iDataServices.GetAllTitles();
            return Ok(titles);
        }*/

        [HttpGet(Name = nameof(GetTitles))]
        public IActionResult GetTitles([FromQuery] QueryString queryString)
        {
            var titles = _iDataServices.GetAllTitles(queryString);

            var items = titles.Select(CreateTitleListViewModel);

            var result = CreateResultModel(queryString, _iDataServices.NumberOffProducts(), items);

            return Ok(result);
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
        
        [HttpGet("searchresult/{titlesearch}")]
        public async Task<ActionResult<TitleSearch>> TitleSearch(string titlesearch)
        {
            Console.WriteLine("HERE" + titlesearch);
            var titleName = _iDataServices.TitleSearch(titlesearch).Result;
            return Ok(titleName);
        }
        
        
        // Helper Methods
        
        private object CreateResultModel(QueryString queryString, int total, IEnumerable<TitleListViewModel> model)
        {
            return new
            {
                total,
                prev = CreateNextPageLink(queryString),
                cur = CreateCurrentPageLink(queryString),
                next = CreateNextPageLink(queryString, total),
                items = model
            };
        }
        
        private string? CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetTitlesUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy);
        }
        
        private string? CreateCurrentPageLink(QueryString queryString)
        {
            return GetTitlesUrl(queryString.Page, queryString.PageSize, queryString.OrderBy);
        }
        
        private string? CreateNextPageLink(QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetTitlesUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? GetTitlesUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(GetTitles),  
                new { page, pageSize, orderBy });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private TitleViewModel CreateTitleViewModel(Titles titles)
        {
            var model = _mapper.Map<TitleViewModel>(titles);
            model.Url = GetTitleUrl(titles);
            return model;
        }

        private TitleListViewModel CreateTitleListViewModel(Titles titles)
        {
            var model = _mapper.Map<TitleListViewModel>(titles);
            model.Url = GetTitleUrl(titles);
            return model;
        }

        private string? GetTitleUrl(Titles titles)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitles), new { titles.TitleId });
        }
        
        
    }
}