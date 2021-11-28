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
    [Route("api/bookmarks")]
    public class BookMarkController : Controller
    {
        private readonly ITitlesDataService _iDataServices;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookMarkController(ITitlesDataService dataServices, LinkGenerator linkGenerator, IMapper mapper)
        {
            _iDataServices = dataServices;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        
        [HttpGet("{userid}/titlebookmarks/{titleid}")]
        public IActionResult GetTitleBookmark(string userid, string titleid)
        {
            var titleBookmark = _iDataServices.GetTitleBookmark(userid, titleid);
            if (titleBookmark == null)
            {
                return NoContent();
            }

            return Ok(titleBookmark);
        }
        
        [HttpPost("{userid}/titlebookmarks/{titleid}")]
        public IActionResult CreateTitleBookmark(string userid, string titleid)
        {
            var titleBookmark = _iDataServices.CreateTitleBookmark(userid, titleid);
            return Ok(titleBookmark);
        }
        
        [HttpDelete("{userid}/titlebookmarks/{titleid}")]
        public IActionResult DeleteTitleBookmark(string userid, string titleid)
        {
            var titleBookmark = _iDataServices.DeleteTitleBookmark(userid, titleid);
            if (titleBookmark)
            {
                return Ok();
            }

            return NotFound();
        }
        
    }
}