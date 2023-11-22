using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwitterCloneFeedServiceAPI.Services;

namespace TwitterCloneFeedServiceAPI.Controllers
{

    [ApiController]
    [Route("api/feed")]
    public class FeedController : ControllerBase
    {
        private readonly FeedService _feedService;

        public FeedController(FeedService feedService)
        {
            _feedService = feedService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFeed(int pageNumber = 1, int pageSize = 10)
        {
            string userId = User.Identity?.Name; // Replace with actual user ID retrieval logic
            var feed = await _feedService.GetUserFeedAsync(userId, pageNumber, pageSize);
            return Ok(feed);
        }
    }

}
