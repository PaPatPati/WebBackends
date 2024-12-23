using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBackendsBidding.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public double Price { get; set; }

        [Required] //Wenn User gelöscht, soll das Bid nicht mehr vorhanden sein
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        public int? ListedArticleId { get; set; }
        [ForeignKey("ListedArticleId")]
        public ListedArticle? ListedArtikle { get; set; }
    }
}
