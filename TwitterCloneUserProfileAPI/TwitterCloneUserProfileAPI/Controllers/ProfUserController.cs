using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwitterCloneUserProfileAPI.Services;
using TwitterCloneUserProfileAPI.DTOs;

namespace TwitterCloneUserProfileAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserProfileService _userProfileService;

        public UserController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetProfile(string id)
        {
            try
            {
                var userProfile = await _userProfileService.GetUserProfileAsync(id);
                if (userProfile == null)
                    return NotFound("User profile not found.");

                return Ok(userProfile);
            }
            catch (System.Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] UpdateUserProfileDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _userProfileService.UpdateUserProfileAsync(id, dto);
                return NoContent();
            }
            catch (System.InvalidOperationException ex)
            {
                // Log the exception message if needed
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(500, "An error occurred while updating the profile.");
            }
        }
    }
}
