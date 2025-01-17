using Microsoft.AspNetCore.Mvc.RazorPages;
using Bidding.WebApp.Services;
using Bidding.WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bidding.WebApp.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly BiddingApiService _apiService;

    public IndexModel(BiddingApiService apiService)
    {
        _apiService = apiService;
    }

    public List<ListingResponse> Listings { get; set; } = new();

    public async Task OnGetAsync()
    {
        Listings = await _apiService.GetListingsAsync();
    }
}

