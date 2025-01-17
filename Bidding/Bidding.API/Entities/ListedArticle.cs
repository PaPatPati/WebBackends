using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bidding.API.Entities;

    public class ListedArticle
    { 
        public int Id { get; set; }
        public required string Title { get; set; }
        public double Price { get; set; }
        public bool IsSold { get; set; }
        public required string Image { get; set; }
        public required string UserId { get; set; } 
        public required IdentityUser User { get; set; }
        public List<Bid?> Bids { get; set; } = [];
    }

