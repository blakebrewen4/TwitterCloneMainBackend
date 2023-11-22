namespace TwitterCloneTweetServiceAPI.DTOs
{
    public class TweetDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }  // Or int, depending on your User model
        public List<CommentDto> Comments { get; set; }
        public int LikeCount { get; set; }
        public int RetweetCount { get; set; }
        // Include fields for attached media if necessary
    }

}
