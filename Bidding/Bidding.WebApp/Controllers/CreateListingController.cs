using Microsoft.AspNetCore.Mvc;
using Bidding.WebApp.Models;
using Bidding.WebApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace Bidding.WebApp.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateListingController : ControllerBase
{
    private readonly BiddingApiService _apiService;

    public CreateListingController(BiddingApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingViewModel request)
    {
        var listingRequest = new ListingRequest
        {
            Title = request.Title,
            Price = request.Price,
            Image = request.Image
        };

        var success = await _apiService.CreateListingAsync(listingRequest);
        if (success)
        {
            return Ok();
        }
        return BadRequest("Failed to create listing");
    }
}
