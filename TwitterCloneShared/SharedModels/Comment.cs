using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterCloneShared.SharedModels
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public string UserId { get; set; } // Updated to string type
        public User User { get; set; }

        [Required]
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }

}

