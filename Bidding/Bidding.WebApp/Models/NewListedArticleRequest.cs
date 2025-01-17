namespace Bidding.WebApp.Models;

public class NewListedArticleRequest
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Image { get; set; }
} 