using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Bidding.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
namespace Bidding.WebApp.Pages;

public class LoginModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoginModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        LoginRequest = new AuthenticationRequest();
    }

    [BindProperty]
    public AuthenticationRequest LoginRequest { get; set; }

    [BindProperty]
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
        // Optionally clear session on logout
        HttpContext.Session.Clear();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var client = _httpClientFactory.CreateClient("ApiClient");
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(LoginRequest),
            Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json")
        );

        var response = await client.PostAsync("user/Login", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<AuthenticationResponse>(responseBody);

            if (authResponse?.Token != null)
            {
                HttpContext.Session.SetString("AuthToken", authResponse.Token);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, LoginRequest.Username)
                };
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToPage("/Index");
            }
        }

        ErrorMessage = "Invalid username or password.";
        return Page();
    }
}
