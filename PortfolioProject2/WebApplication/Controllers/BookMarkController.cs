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
using WebApplication.DataInterfaces;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookMarkController : Controller
    {
        private readonly IBookMarkDataService _iBookMarkDataService;
        private readonly IActorDataService _iActorDataServices;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookMarkController(IBookMarkDataService bookmarkdataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _iBookMarkDataService = bookmarkdataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        
        //for titles bookmark
        
        [HttpGet("{userid}/titlebookmarks/{titleid}")]
        public IActionResult GetTitleBookmark(int userid, string titleid)
        {
            var titleBookmark = _iBookMarkDataService.GetTitleBookmark(userid, titleid);
            if (titleBookmark == null)
            {
                return NoContent();
            }

            return Ok(titleBookmark);
        }
        
        [HttpGet("{userid}/titlebookmarks")]
        public IActionResult GetTitleBookmarks(int userid)
        {
            var titleBookmarks = _iBookMarkDataService.GetTitleBookmarks(userid);
            if (titleBookmarks == null)
            {
                return NotFound();
            }

            return Ok(titleBookmarks);
        }
        
        [HttpPost]//("{userid}/titlebookmarks/{titleid}")]
        public IActionResult CreateTitleBookmark(int userid, string titleid)
        {
            var titleBookmark = _iBookMarkDataService.CreateTitleBookmark(userid, titleid);
            return Ok(titleBookmark);
        }
        
        [HttpDelete("{userid}/titlebookmarks/{titleid}")]
        public IActionResult DeleteTitleBookmark(int userid, string titleid)
        {
            var titleBookmark = _iBookMarkDataService.DeleteTitleBookmark(userid, titleid);
            if (titleBookmark)
            {
                return Ok();
            }

            return NotFound();
        }
        
        //for actor bookmark
        
        [HttpGet("{userid}/namebookmarks/{pid}")]
        public IActionResult GetNameBookmark(int userid, string pid)
        {
            var nameBookmark = _iBookMarkDataService.GetNameBookmark(userid, pid);
            if (nameBookmark == null)
            {
                return NoContent();
            }

            return Ok(nameBookmark);
        }
        
        [HttpGet("{userid}/namebookmarks")]
        public IActionResult GetNameBookmarks(int userid)
        {
            var nameBookmarks = _iBookMarkDataService.GetNameBookmarks(userid);
            if (nameBookmarks == null)
            {
                return NotFound();
            }
            return Ok(nameBookmarks);
        }

        [HttpPost("{userid}/namebookmarks/{pid}")]
        public IActionResult CreateNameBookmark(Name_Bookmark nameBookmark)
        {
            var result = _iBookMarkDataService.CreateNameBookmark(nameBookmark.UserId, nameBookmark.Pid);
            return Ok(result);
        }
        
    }
}