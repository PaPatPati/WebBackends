using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Bidding.WebApp.Controllers;
using Bidding.WebApp.Models;
using Bidding.WebApp.Services;

namespace Bidding.WebApp.Pages;

public class CreateListingModel : PageModel
{
    private readonly BiddingApiService _apiService;

    public CreateListingModel(BiddingApiService apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public CreateListingViewModel Listing { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var listingRequest = new ListingRequest
        {
            Title = Listing.Title,
            Price = Listing.Price,
            Image = Listing.Image
        };

        var success = await _apiService.CreateListingAsync(listingRequest);
        if (success)
        {
            return RedirectToPage("Index");
        }

        ModelState.AddModelError("", "Failed to create listing");
        return Page();
    }
}