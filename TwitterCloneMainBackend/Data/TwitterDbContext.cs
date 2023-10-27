using Microsoft.EntityFrameworkCore;
using TwitterCloneMainBackend.Models;
using Microsoft.Extensions.Configuration;
using Humanizer.Configuration;

namespace TwitterCloneMainBackend.Data
{
    public class TwitterDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }
        
        public TwitterDbContext(DbContextOptions<TwitterDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollow>()
            .HasKey(uf => new { uf.FollowerId, uf.FollowingId });

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict); // You can change the delete behavior as needed

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.FollowedUser)
                .WithMany()
                .HasForeignKey(uf => uf.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    

}

