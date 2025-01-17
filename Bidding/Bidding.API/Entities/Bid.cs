using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bidding.API.Entities;

public class Bid
{ 
    public int Id { get; set; }
    public double Price { get; set; }

    public required string UserId { get; set; }

    public required IdentityUser User { get; set; }

    public int ListedArticleId { get; set; }
    public required ListedArticle ListedArticle { get; set; }
}

