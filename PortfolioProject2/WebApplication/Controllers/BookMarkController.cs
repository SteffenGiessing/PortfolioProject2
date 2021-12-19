/*
 * The user shall be able to bookmark movies in the system.
 * The Bookmark Controller is responsible for communication between our frontend and the "backend".
 */

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;
using WebApplication.DTOs;
using WebApplication.Token;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookMarkController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IBookMarkDataService _iBookMarkDataService;
        private readonly IActorDataService _iActorDataServices;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookMarkController(IBookMarkDataService bookmarkdataservice, LinkGenerator linkGenerator, IMapper mapper,
            IConfiguration config)
        {
            _iBookMarkDataService = bookmarkdataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _config = config;
        }

        /*
         * Getting a specific bookmarks created by a user.
         * Based upon userid and titleid.
         */
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

        /*
         * Getting all the title bookmarks created by a user.
         */
        [HttpGet("{userid}/titlebookmarks")]
        public IActionResult GetTitleBookmarks(int userid, [FromHeader] TokenChecker getHeaders)
        {
            var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);
            if (token == true)
            {
                var titleBookmarks = _iBookMarkDataService.GetTitleBookmarks(userid);
                if (titleBookmarks == null)
                {
                    return NotFound();
                }

                return Ok(titleBookmarks);
            }

            return Unauthorized();
        }

        /*
         * Creating a title bookmark on a users request. 
         */
        [HttpPost("{userid}/titlebookmarks/{titleid}")]
        public IActionResult CreateTitleBookmark(int userid, string titleid, [FromHeader] TokenChecker getHeaders)
        {
            var token = TokenCreator.ValidateToken(getHeaders.Authorization, _config);
            if (token == true)
            {
                var titleBookmark = _iBookMarkDataService.CreateTitleBookmark(userid, titleid);
                if (titleBookmark == null)
                {
                    return NotFound();
                }

                return Ok(titleBookmark);
            }

            return Unauthorized();
        }

        /*
         * Deleting a specific bookmark.
         */
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

        /*
         * These methods were created because we had an orginal plan to allow our users to bookmark actors as well.
         * We have left them because we might come back to that thought in the future.
         */
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