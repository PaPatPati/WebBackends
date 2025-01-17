using System.ComponentModel.DataAnnotations;

namespace Bidding.API.Models.RequestModels;

public class UpdateListedArticleRequest
{
    public required int Id { get; set; }
    public required bool IsSold { get; set; }
}

