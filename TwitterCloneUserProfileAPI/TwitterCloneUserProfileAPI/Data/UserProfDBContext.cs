using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneUserProfileAPI.Data
{
    public class UserProfDBContext : IdentityDbContext<User>
    {
        public UserProfDBContext(DbContextOptions<UserProfDBContext> options)
            : base(options)
        {
        }

        // Your DbSets
        public DbSet<User> Users { get; set; }
    }
}

