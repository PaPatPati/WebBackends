using System.Security.Claims;
using Bidding.API.Models.RequestModels;
using Bidding.API.Services.JwtService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{
    [Route("bid")]
    [ApiController]
    public class BidController : ControllerBase
    {

        private readonly IBidService _bidService;


        public BidController(
            IBidService bidService
        )
        {
            _bidService = bidService;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<ActionResult> PostBid(NewBidRequest newBid)
        {
            var userId = User.FindFirstValue("UserId")!;

            var result = await _bidService.CreateBid(newBid, userId);

            return Ok(result);
        }
       
        [Authorize]
        [HttpGet("{listedArticleId}")]
        public async Task<ActionResult> GetBidsByListedArticleId(int listedArticleId)
        {
            var result = await _bidService.GetBidsByListedArticleId(listedArticleId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetBidsByUserId(string userId)
        {
            var result = await _bidService.GetBidsByUserId(userId);

            return Ok(result);
        }
    }
    }
