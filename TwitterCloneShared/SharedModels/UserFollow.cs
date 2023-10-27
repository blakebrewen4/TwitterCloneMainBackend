namespace TwitterCloneShared.SharedModels
{
    public class UserFollow
    {
        // Represents a relationship where one user follows another
        public int FollowerId { get; set; }
        public User Follower { get; set; }

        public int FollowingId { get; set; }
        public User FollowedUser { get; set; }
    }
}
