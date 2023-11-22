using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;
using TwitterCloneFeedServiceAPI.DTOs;
using TwitterCloneFeedServiceAPI.Data;

namespace TwitterCloneFeedServiceAPI.Services
{

    public class FeedService
    {
        private readonly TwitterCloneFeedDbContext _context;

        public FeedService(TwitterCloneFeedDbContext context)
        {
            _context = context;
        }

        public async Task<List<TweetDto>> GetUserFeedAsync(string userId, int pageNumber, int pageSize)
        {
            // This assumes you have a way to get the list of users that the current user follows
            var userFollowings = await GetUserFollowings(userId);

            var tweets = await _context.Tweets
                .Where(t => t.UserId == userId || userFollowings.Contains(t.UserId))
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TweetDto
                {
                    // Map the necessary fields
                    Id = t.Id,
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    UserId = t.UserId
                    // Add other fields as necessary
                })
                .ToListAsync();

            return tweets;
        }

        private async Task<List<string>> GetUserFollowings(string userId)
        {
            // Implement logic to retrieve the list of user IDs that the given user is following
            // Example: _context.Followings.Where(f => f.FollowerId == userId).Select(f => f.FollowingId).ToListAsync();
            return new List<string>(); // Placeholder
        }
    }

}
