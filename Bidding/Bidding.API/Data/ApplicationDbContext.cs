using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bidding.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bidding.API.Data;

public class ApplicationDbContext : IdentityUserContext<IdentityUser>
{
        private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
    IConfiguration configuration
    )
        : base(options)
    {
        _configuration = configuration;
    }

    //Properties
    public DbSet<ListedArticle> ListedArticles { get; set; }
    public DbSet<Bid> Bids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
    
    
}
