using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterCloneShared.SharedModels
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }  // 'Content' is a more descriptive name than 'Text'

        public DateTime CreatedAt { get; set; }  // 'CreatedAt' is more universally understood than 'CreatedDate'

        // Foreign key to the User who posted the comment
        [Required]
        public int UserId { get; set; }  // Assuming User's Id is of type int; change if needed
        public User User { get; set; }

        // Foreign key to the Tweet that was commented on
        [Required]
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}

