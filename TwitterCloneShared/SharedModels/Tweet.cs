using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterCloneShared.SharedModels
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(280)]
        public string Content { get; set; }  // Using the 'Content' property name for clarity

        public DateTime CreatedAt { get; set; }  // 'CreatedAt' is more universally understood than 'CreatedDate'

        // Foreign key to the User who created the tweet
        // Note: Using 'int' for UserId as in the model you want to retain, 
        // but you might need to adjust if your user model uses a string identifier.
        public string UserId { get; set; }
        public User User { get; set; }

        // Navigation properties for likes and comments
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // Property for retweet count from the second model
        public int RetweetCount { get; set; }
    }
}
