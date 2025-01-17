using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using Bidding.WebApp.Models;

namespace Bidding.WebApp.Pages;
public class RegisterModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegisterModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        RegisterRequest = new NewUserRequest();
    }

    [BindProperty]
    public NewUserRequest RegisterRequest { get; set; }

    [BindProperty]
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var client = _httpClientFactory.CreateClient("ApiClient");
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(RegisterRequest),
            Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json")
        );

        var response = await client.PostAsync("user/Register", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Registration successful! Please login.";
            return RedirectToPage("/Login");
        }

        ErrorMessage = "Failed to register. Please try again.";
        return Page();
    }
}