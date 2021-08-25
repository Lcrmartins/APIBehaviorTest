namespace APIBehaviorTest.Data
{
    
    /// <summary>
    /// This class specifies the form of the Tweet, considering the task proposed. Al the properties are presented. The tweets in the Twitters page has more data, not included in this scope.
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// This property individualize the Tweet.  
        /// </summary>
        /// <value>This string contains information of the tweeter origin.</value>
        public string UniqueId { get; set; }
        
        /// <summary>
        /// This property contains the content of the tweet. 
        /// </summary>
        /// <value>This string is formed by the concatenation of the three existing blocs of content in the tweet.</value>
        public string Content { get; set; }
        
        /// <summary>
        /// This property contains the information about the tweet's post date.
        /// </summary>
        /// <value>This string contains the information of year, month, day, hour, minute, second and millisecond. The time is in UTC.</value>
        public string TimeStamp { get; set; }
        
        /// <summary>
        /// This property indicates the origin account of the tweeter.
        /// </summary>
        /// <value>This is a string property</value>
        public string Account { get; set; }
        
        /// <summary>
        /// This property indicates the engagement of the tweeter, in terms of replies.
        /// </summary>
        /// <value>This integer represents the number of replies the tweet received. Initially was a string. The precision is of one from zero to 999, 100 from 1,000 to 999,000 and 100,000 above.</value>
        public int Replies { get; set; }
        
        /// <summary>
        /// This property indicates the engagement of the tweeter, in terms of retweets.
        /// </summary>
        /// <value>This integer represents the number of retweets the tweet received. Initially was a string. The precision is of one from zero to 999, 100 from 1,000 to 999,000 and 100,000 above.</value>
        public int Retweets { get; set; }
        
        /// <summary>
        /// This property indicates the engagement of the tweeter, in terms of likes.
        /// </summary>
        /// <value>This integer represents the number of likes (or faves) the tweet received. Initially was a string. The precision is of one from zero to 999, 100 from 1,000 to 999,000 and 100,000 above.</value>
        public int Likes { get; set; }
    }
}