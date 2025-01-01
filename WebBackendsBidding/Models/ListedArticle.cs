using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBackendsBidding.Models
{
    public class ListedArticle
    { //Entity
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public bool IsSold { get; set; }
        public string PathToImage { get; set; }

        [Required] //Wenn User gelöscht soll der Artikel nicht mehr gelistet sein
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
        public List<Bid?> Bids { get; set; }


    }
}
