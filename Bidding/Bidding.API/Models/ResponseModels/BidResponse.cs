namespace Bidding.API.Models.ResponseModels;

public class BidResponse
{
    public int Id { get; set; }
    public double Price { get; set; }
    public required string UserId { get; set; }
    public required string UserName { get; set; }
    public int ListedArticleId { get; set; }
}

