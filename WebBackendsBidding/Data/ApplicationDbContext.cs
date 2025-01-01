using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebBackendsBidding.Models;

namespace WebBackendsBidding.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Properties
        public DbSet<ListedArticle> ListedArticles { get; set; }
        public DbSet<Bid> Bids { get; set; }
        
    }
}
