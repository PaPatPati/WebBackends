using Bidding.WebApp.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Bidding.WebApp.Services;

public class BiddingApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BiddingApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
        _httpContextAccessor = httpContextAccessor;
    }

    private void AddAuthToken()
    {
        var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<bool> CreateListingAsync(ListingRequest listing, IFormFile? image = null)
    {
        AddAuthToken();
        
        string? base64Image = null;
        if (image != null)
        {
            using var ms = new MemoryStream();
            await image.CopyToAsync(ms);
            base64Image = Convert.ToBase64String(ms.ToArray());
        }

        var listingData = new
        {
            Title = listing.Title,
            Price = listing.Price,
            Image = base64Image
        };

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(listingData),
            Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json")
        );

        var response = await _httpClient.PostAsync("api/listings", jsonContent);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ListingResponse>> GetListingsAsync()
    {
        AddAuthToken();
        var response = await _httpClient.GetAsync("api/listings");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<ListingResponse>>() ?? new();
        }
        return new();
    }

} 