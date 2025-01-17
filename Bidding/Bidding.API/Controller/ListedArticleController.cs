using System.Security.Claims;
using Bidding.API.Entities;
using Bidding.API.Models.RequestModels;
using Bidding.API.Services.JwtService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{
    [Route("listed-article")]
    [ApiController]
    public class ListedArticleController : ControllerBase
    {

        private readonly IListedArticleService _listedArticleService;


        public ListedArticleController(
            IListedArticleService listedArticleService
        )
        {
            _listedArticleService = listedArticleService;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<ActionResult> PostListedArticle(NewListedArticleRequest newListedArticle)
        {
            var userId = User.FindFirstValue("UserId")!;

            var result = await _listedArticleService.CreateListedArticle(newListedArticle, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("")]
        public async Task<ActionResult> PutListedArticle(UpdateListedArticleRequest updateListedArticle)
        {
            var userId = User.FindFirstValue("UserId")!;

            var result = await _listedArticleService.UpdateListedArticle(updateListedArticle, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("")]
        public async Task<ActionResult> GetListedArticles()
        {
            var result = await _listedArticleService.GetListedArticles();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetListedArticlesByUserId(string userId)
        {
            var result = await _listedArticleService.GetListedArticlesByUserId(userId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("sold")]
        public async Task<ActionResult> GetSoldArticles()
        {
            var result = await _listedArticleService.GetSoldArticles();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("won")]
        public async Task<ActionResult> GetWonArticles()
        {
            var userId = User.FindFirstValue("UserId")!;

            var result = await _listedArticleService.GetWonArticles(userId);

            return Ok(result);
        }
    }
    }
