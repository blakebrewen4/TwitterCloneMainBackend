using System.ComponentModel.DataAnnotations;

namespace TwitterCloneMainBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign key to the User who posted the comment
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key to the Tweet that was commented on
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}
