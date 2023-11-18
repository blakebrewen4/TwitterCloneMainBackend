using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterCloneShared.SharedModels
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        [MaxLength(200)]
        public string Bio { get; set; }

        // Navigation properties
        public ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserFollow> Followers { get; set; } = new List<UserFollow>();
        public ICollection<UserFollow> Followings { get; set; } = new List<UserFollow>();
    }
}

