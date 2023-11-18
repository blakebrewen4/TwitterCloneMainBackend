using Microsoft.EntityFrameworkCore;
using System.Linq;
using TwitterCloneAPIUserAuth2._0.Data;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneAPIUserAuth2._0.Repositories
{
    public class UserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public User GetById(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

    }
}
