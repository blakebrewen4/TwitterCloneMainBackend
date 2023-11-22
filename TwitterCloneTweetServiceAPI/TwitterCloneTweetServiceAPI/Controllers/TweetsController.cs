using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwitterCloneTweetServiceAPI.Services;
using TwitterCloneShared.SharedModels;
using TwitterCloneTweetServiceAPI.DTOs;

[ApiController]
[Route("api/tweets")]
public class TweetsController : ControllerBase
{
    private readonly TweetService _tweetService;

    public TweetsController(TweetService tweetService)
    {
        _tweetService = tweetService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTweet(CreateTweetDto dto)
    {
        // Replace this with actual logic to retrieve the authenticated user's ID
        string userId = User.Identity?.Name; // or another way to get the user's ID

        var tweet = await _tweetService.CreateTweetAsync(userId, dto);
        return CreatedAtAction(nameof(GetTweet), new { id = tweet.Id }, tweet);
    }

    [HttpPost("{tweetId}/like")]
    public async Task<IActionResult> LikeTweet(int tweetId)
    {
        string userId = User.Identity?.Name; // Replace with actual user ID retrieval logic
        await _tweetService.LikeTweetAsync(tweetId, userId);
        return Ok();
    }

    [HttpPost("{tweetId}/comment")]
    public async Task<IActionResult> CommentOnTweet(int tweetId, CreateCommentDto dto)
    {
        string userId = User.Identity?.Name; // Replace with actual user ID retrieval logic
        await _tweetService.CommentOnTweetAsync(tweetId, userId, dto);
        return Ok();
    }

    [HttpPost("{tweetId}/retweet")]
    public async Task<IActionResult> Retweet(int tweetId)
    {
        string userId = User.Identity?.Name; // Replace with actual user ID retrieval logic
        await _tweetService.RetweetAsync(tweetId, userId);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTweet(int id)
    {
        // Logic to get a tweet by ID. Implement this in your TweetService.
        // var tweet = await _tweetService.GetTweetByIdAsync(id);
        // if (tweet == null) return NotFound();

        // return Ok(tweet);
        return Ok(); // Placeholder, replace with actual implementation
    }
}
