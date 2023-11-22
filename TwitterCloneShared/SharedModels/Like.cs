namespace TwitterCloneShared.SharedModels
{
    public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // Assuming User's Id is a string
        public User User { get; set; }
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }

}

