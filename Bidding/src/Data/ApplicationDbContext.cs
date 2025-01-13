using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bidding.Models;

namespace Bidding.Data;
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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListedArticle>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<ListedArticle>()
                .HasMany(e => e.Bids)
                .WithOne(e => e.ListedArticle)
                .HasForeignKey(e => e.ListedArticleId);

            modelBuilder.Entity<Bid>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Bid>()
                .HasOne(e => e.ListedArticle)
                .WithMany(e => e.Bids)
                .HasForeignKey(e => e.ListedArticleId);

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<User>()
                .HasMany(e => e.ListedArticles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bids)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            base.OnModelCreating(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var connectionString = dbConnectionFactory.GetConnection();
                optionsBuilder.UseNpgsql(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
        
        
    }
}
