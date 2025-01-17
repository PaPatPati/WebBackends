namespace Bidding.API.Models.RequestModels;

public class NewBidRequest
{
    public required int ListedArticleId { get; set; }
    public required double Price { get; set; }
}

