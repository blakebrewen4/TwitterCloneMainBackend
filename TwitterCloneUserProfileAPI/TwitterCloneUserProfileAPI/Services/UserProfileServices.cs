using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;
using TwitterCloneUserProfileAPI.Data;
using TwitterCloneUserProfileAPI.DTOs;

namespace TwitterCloneUserProfileAPI.Services
{
    public class UserProfileService
    {
        private readonly UserProfDBContext _context;

        public UserProfileService(UserProfDBContext context)
        {
            _context = context;
        }

        public async Task<UserProfileDto> GetUserProfileAsync(string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserProfileDto
                {
                    // Map the properties from User to UserProfileDto
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Bio = u.Bio,
                    ProfilePictureUrl = u.ProfilePictureUrl
                })
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task UpdateUserProfileAsync(string userId, UpdateUserProfileDto updateDto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                // Update the properties of user
                user.FirstName = updateDto.FirstName;
                user.LastName = updateDto.LastName;
                user.Email = updateDto.Email; // Be cautious about updating emails
                user.Bio = updateDto.Bio;
                user.ProfilePictureUrl = updateDto.ProfilePictureUrl;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }
    }
}
