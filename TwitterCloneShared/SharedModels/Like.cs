namespace TwitterCloneShared.SharedModels
{
    public class Like
    {
        public int Id { get; set; }

        // Foreign key to the User who liked the tweet
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key to the Tweet that was liked
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}
