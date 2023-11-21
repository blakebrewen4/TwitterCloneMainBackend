namespace TwitterCloneUserProfileAPI.DTOs
{
    public class UpdateUserProfileDto
    {
        // Assuming FirstName and LastName are part of the user profile
        // If UserName is immutable or used for login purposes, it's better not to include it here
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }

        // Email is typically critical for authentication and might need additional verification if updated
        // public string Email { get; set; }

        // Add any other fields that your application might require
        // Like 'Location', 'WebsiteUrl', etc.
    }
}
