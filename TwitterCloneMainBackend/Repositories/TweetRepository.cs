using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterCloneShared.SharedModels;
using Microsoft.EntityFrameworkCore;
using TwitterCloneMainBackend.Data;

namespace TwitterCloneMainBackend.Repositories
{
    public class TweetRepository
    {
        private readonly TwitterDbContext _context;

        public TweetRepository(TwitterDbContext context)
        {
            _context = context;
        }

        public async Task<Tweet> GetByIdAsync(int tweetId)
        {
            return await _context.Tweets.FirstOrDefaultAsync(t => t.Id == tweetId);
        }

        public async Task<Tweet> CreateAsync(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();
            return tweet;
        }

        public async Task<IEnumerable<Tweet>> GetAllTweetsAsync()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task DeleteAsync(Tweet tweet)
        {
            _context.Tweets.Remove(tweet);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasUserTweetedSameContentBeforeAsync(string userId, string content)
        {
            return await _context.Tweets.AnyAsync(t => t.UserId == userId && t.Content == content);
        }
    }
}
