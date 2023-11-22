using System.ComponentModel.DataAnnotations;


namespace TwitterCloneTweetServiceAPI.DTOs


{
    public class CreateTweetDto
    {
        [Required]
        [MaxLength(280)]
        public string Content { get; set; }
        // Fields for attached media
    }
}