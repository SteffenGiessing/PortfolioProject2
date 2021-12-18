#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PortfolioProject2.Models.DMOs;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;
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

        [HttpGet(Name = nameof(GetTitles))]
        public IActionResult GetTitles([FromQuery] QueryString queryString)
        {
            var titles = _iDataServices.GetAllTitles(queryString);

            var items = titles.Select(CreateTitleListViewModel);

            var result = CreateResultModel(queryString, _iDataServices.NumberOffProducts(), items);

            return Ok(result);
        }

        [HttpGet("populartitles", Name = nameof(GetPopularTitles))]
        public IActionResult GetPopularTitles([FromQuery] QueryString queryString)
        {
            var popularTitles = _iDataServices.GetPopularTitles(queryString);
            var items = popularTitles.Select(CreatePopularListViewModel);
            var result = CreateResultModelForPopular(queryString, _iDataServices.NumberOffProducts(), items);
            return Ok(result);
        }

        /*[HttpGet("searchresult/{titlesearch}", Name = nameof(TitleSearch))]
        public IActionResult TitleSearch([FromQuery] QueryString queryString, string titleSearch)
        {
            var searchedItems = _iDataServices.TitleSearch(queryString, titleSearch);
            var items = searchedItems.Select(CreateSearchListViewModel);
            var result = CreateResultModelForSearch(queryString, _iDataServices.NumberOffProducts(), items);
            return Ok(result);
        }*/

        [HttpGet("searchresult/{titlesearch}")]
        public async Task<ActionResult<TitleSearch>> TitleSearch(string titlesearch)
        {
            Console.WriteLine("HERE" + titlesearch);
            var titleName = _iDataServices.TitleSearch(titlesearch).Result;
            return Ok(titleName);
        }

        [HttpGet("{titleId?}")]
        public async Task<ActionResult<Titles>> getTitleById(string? titleId)
        {
            var titles = _iDataServices.GetTitleById(titleId).Result;
            return Ok(titles);
        }

        [HttpGet("result/{titleName}")]
        public async Task<ActionResult<Titles>> getTitleByName(string? titleName)
        {
            var nameTitles = _iDataServices.GetTitleByName(titleName).Result;
            return Ok(nameTitles);
        }


        [HttpGet("titleinfo/{titleid?}")]
        public async Task<ActionResult<Title_Info>> GetInfoSpecificTitle(string? titleid)
        {
            var titleInfo = _iDataServices.GetInfoSpecificTitle(titleid).Result;
            return Ok(titleInfo);
        }
        /*
         * [HttpGet("{pid}")]
        public async Task<ActionResult<Person_Info>> getPersonKnownFor(string? pid)
        {
            var personKnownFor = _iDataServices.GetPersonKnownFor(pid).Result;
            return Ok(personKnownFor);
        }
         */

        // Helper Methods // 
        private static int GetLastPage(int pageSize, int total)
        {
            return (int) Math.Ceiling(total / (double) pageSize) - 1;
        }

        // For popular Titles
        private object CreateResultModelForPopular(QueryString queryString, int total,
            IEnumerable<PopularListViewModel> model)
        {
            return new
            {
                total,
                prev = CreatePrevPageLinkForPopular(queryString),
                cur = CreateCurrentPageLinkForPopular(queryString),
                next = CreateNextPageLinkForPopular(queryString, total),
                items = model
            };
        }

        private string? CreateNextPageLinkForPopular(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage
                ? null
                : GetPopularTitleUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? CreateCurrentPageLinkForPopular(QueryString queryString)
        {
            return GetPopularTitleUrl(queryString.Page, queryString.PageSize, queryString.OrderBy);
        }

        private string? CreatePrevPageLinkForPopular(QueryString queryString)
        {
            return queryString.Page <= 0
                ? null
                : GetPopularTitleUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? GetPopularTitleUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(GetPopularTitles),
                new {page, pageSize, orderBy});
        }

        private PopularViewModel CreatePopularViewModel(PopularTitles popularTitles)
        {
            var model = _mapper.Map<PopularViewModel>(popularTitles);
            model.Url = PopularTitleUrl(popularTitles);
            return model;
        }

        private PopularListViewModel CreatePopularListViewModel(PopularTitles popularTitles)
        {
            var model = _mapper.Map<PopularListViewModel>(popularTitles);
            model.Url = PopularTitleUrl(popularTitles);
            return model;
        }

        private string? PopularTitleUrl(PopularTitles popularTitles)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetPopularTitles), new {popularTitles.TitleId});
        }

        // For Searched Titles
        private object CreateResultModelForSearch(QueryString queryString, int total,
            IEnumerable<SearchListViewModel> model)
        {
            return new
            {
                total,
                prev = CreatePrevPageLinkForSearch(queryString),
                cur = CreateCurrentPageLinkForSearch(queryString),
                next = CreateNextPageLinkForSearch(queryString, total),
                items = model
            };
        }

        private string? CreateNextPageLinkForSearch(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage
                ? null
                : GetSearchTitleUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? CreateCurrentPageLinkForSearch(QueryString queryString)
        {
            return GetSearchTitleUrl(queryString.Page, queryString.PageSize, queryString.OrderBy);
        }

        private string? CreatePrevPageLinkForSearch(QueryString queryString)
        {
            return queryString.Page <= 0
                ? null
                : GetSearchTitleUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? GetSearchTitleUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(TitleSearch),
                new {page, pageSize, orderBy});
        }


        private SearchViewModel CreateSearchViewModel(TitleSearch titleSearch)
        {
            var model = _mapper.Map<SearchViewModel>(titleSearch);
            model.Url = GetSearcheUrl(titleSearch);
            return model;
        }

        private SearchListViewModel CreateSearchListViewModel(TitleSearch titleSearch)
        {
            var model = _mapper.Map<SearchListViewModel>(titleSearch);
            model.Url = GetSearcheUrl(titleSearch);
            return model;
        }

        private string? GetSearcheUrl(TitleSearch titleSearch)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(TitleSearch), new {titleSearch.TitleId});
        }

        // For all Titles
        private object CreateResultModel(QueryString queryString, int total, IEnumerable<TitleListViewModel> model)
        {
            return new
            {
                total,
                prev = CreatePrevPageLink(queryString),
                cur = CreateCurrentPageLink(queryString),
                next = CreateNextPageLink(queryString, total),
                items = model
            };
        }

        private string? CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage
                ? null
                : GetTitlesUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? CreateCurrentPageLink(QueryString queryString)
        {
            return GetTitlesUrl(queryString.Page, queryString.PageSize, queryString.OrderBy);
        }

        private string? CreatePrevPageLink(QueryString queryString)
        {
            return queryString.Page <= 0
                ? null
                : GetTitlesUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy);
        }

        private string? GetTitlesUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(GetTitles),
                new {page, pageSize, orderBy});
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
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitles), new {titles.TitleId});
        }
    }
}