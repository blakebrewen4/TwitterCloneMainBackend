using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneTweetServiceAPI.Data
{
    public class TwitterCloneTweetDbContext : DbContext
    {
        public TwitterCloneTweetDbContext(DbContextOptions<TwitterCloneTweetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Retweet> Retweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships, indexes, and additional configurations here if necessary
        }
    }
}
