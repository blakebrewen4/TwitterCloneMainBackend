using System.ComponentModel.DataAnnotations;


namespace TwitterCloneTweetServiceAPI.DTOs
{
    public class CreateCommentDto
    {
        [Required]
        public string Content { get; set; }
    }

}
