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
using IActorDataService = WebApplication.DataInterfaces.IActorDataService;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookMarkController : Controller
    {
        private readonly ITitlesDataService _iTitleDataServices;
        private readonly IActorDataService _iActorDataServices;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookMarkController(ITitlesDataService titledataServices, IActorDataService actordataServices,  LinkGenerator linkGenerator, IMapper mapper)
        {
            _iTitleDataServices = titledataServices;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _iActorDataServices = actordataServices;
        }
        
        //for titles bookmark
        
        [HttpGet("{userid}/titlebookmarks/{titleid}")]
        public IActionResult GetTitleBookmark(string userid, string titleid)
        {
            var titleBookmark = _iTitleDataServices.GetTitleBookmark(userid, titleid);
            if (titleBookmark == null)
            {
                return NoContent();
            }

            return Ok(titleBookmark);
        }
        
        [HttpGet("{userid}/titlebookmarks")]
        public IActionResult GetTitleBookmarks(string uconst)
        {
            var titleBookmarks = _iTitleDataServices.GetTitleBookmarks(uconst);
            if (titleBookmarks == null)
            {
                return NotFound();
            }

            return Ok(titleBookmarks);
        }
        
        [HttpPost("{userid}/titlebookmarks/{titleid}")]
        public IActionResult CreateTitleBookmark(string userid, string titleid)
        {
            var titleBookmark = _iTitleDataServices.CreateTitleBookmark(userid, titleid);
            return Ok(titleBookmark);
        }
        
        [HttpDelete("{userid}/titlebookmarks/{titleid}")]
        public IActionResult DeleteTitleBookmark(string userid, string titleid)
        {
            var titleBookmark = _iTitleDataServices.DeleteTitleBookmark(userid, titleid);
            if (titleBookmark)
            {
                return Ok();
            }

            return NotFound();
        }
        
        //for actor bookmark
        
        [HttpGet("{userid}/namebookmarks/{pid}")]
        public IActionResult GetNameBookmark(string userid, string pid)
        {
            var nameBookmark = _iActorDataServices.GetNameBookmark(userid, pid);
            if (nameBookmark == null)
            {
                return NoContent();
            }

            return Ok(nameBookmark);
        }
        
        [HttpGet("{userid}/namebookmarks")]
        public IActionResult GetNameBookmarks(string userid)
        {
            var nameBookmarks = _iActorDataServices.GetNameBookmarks(userid);
            if (nameBookmarks == null)
            {
                return NotFound();
            }
            return Ok(nameBookmarks);
        }

        [HttpPost("{userid}/namebookmarks/{pid}")]
        public IActionResult CreateNameBookmark(Name_Bookmark nameBookmark)
        {
            var result = _iActorDataServices.CreateNameBookmark(nameBookmark.UserId, nameBookmark.Pid);
            return Ok(result);
        }
        
    }
}