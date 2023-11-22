using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;
using TwitterCloneTweetServiceAPI.Data;
using TwitterCloneTweetServiceAPI.DTOs;

namespace TwitterCloneTweetServiceAPI.Services
{
    public class TweetService
    {
        private readonly TwitterCloneTweetDbContext _context;

        public TweetService(TwitterCloneTweetDbContext context)
        {
            _context = context;
        }

        public async Task<Tweet> CreateTweetAsync(string userId, CreateTweetDto dto)
        {
            var tweet = new Tweet
            {
                UserId = userId,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
                // Add additional fields like attached media if needed
            };

            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();
            return tweet;
        }

        public async Task LikeTweetAsync(int tweetId, string userId)
        {
            var existingLike = await _context.Likes.FirstOrDefaultAsync(l => l.TweetId == tweetId && l.UserId == userId);

            if (existingLike != null)
            {
                // User already liked the tweet, remove the like
                _context.Likes.Remove(existingLike);
            }
            else
            {
                // Add a new like
                var like = new Like
                {
                    TweetId = tweetId,
                    UserId = userId
                };
                _context.Likes.Add(like);
            }

            await _context.SaveChangesAsync();
        }

        public async Task CommentOnTweetAsync(int tweetId, string userId, CreateCommentDto dto)
        {
            var comment = new Comment
            {
                TweetId = tweetId,
                UserId = userId,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task RetweetAsync(int tweetId, string userId)
        {
            var retweet = new Retweet
            {
                TweetId = tweetId,
                UserId = userId,
                Timestamp = DateTime.UtcNow
            };

            _context.Retweets.Add(retweet);
            await _context.SaveChangesAsync();
        }
    }
}
