using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace TwitterCloneMainBackend.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(280)]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign key to the User who created the tweet
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation properties
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
