
namespace Bidding.API.Models.RequestModels;

public class NewListedArticleRequest
{
    public required string Title { get; set; }
    public required double Price { get; set; } 
    public required string Image { get; set; }
}

