namespace TwitterCloneFeedServiceAPI.DTOs
{
    public class TweetDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        // Add other necessary properties
    }

}
