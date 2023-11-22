using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterCloneShared.SharedModels
{
    public class Retweet
    {
        public int Id { get; set; }
        public int TweetId { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
