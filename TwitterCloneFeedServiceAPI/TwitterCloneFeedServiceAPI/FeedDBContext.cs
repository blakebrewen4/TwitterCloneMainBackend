using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels; // Adjust this to the actual location of your models

namespace TwitterCloneFeedServiceAPI.Data
{
    public class TwitterCloneFeedDbContext : DbContext
    {
        public TwitterCloneFeedDbContext(DbContextOptions<TwitterCloneFeedDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; } // If you have a separate User model
        // Other DbSets like Comments, Likes, Follows, etc., if they are part of your model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships and configurations here
            // Example: modelBuilder.Entity<Tweet>().ToTable("Tweets");
        }
    }
}
