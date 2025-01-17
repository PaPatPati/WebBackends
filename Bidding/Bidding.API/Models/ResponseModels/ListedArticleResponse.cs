namespace Bidding.API.Models.ResponseModels;

public class ListedArticleResponse
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public double Price { get; set; }
    public bool IsSold { get; set; }
    public required string Image { get; set; }
    public required string UserId { get; set; }
    public required string UserName { get; set; }
}

