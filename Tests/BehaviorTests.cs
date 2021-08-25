using System;
using static System.Console;
using APIBehaviorTest.Data;
using System.Collections.Generic;
using APIBehaviorTest.Services;

namespace APIBehaviorTest.Tests
{
    public static class BehaviorTests
    {                    

        /// <summary>
        /// This Test verifies if the quantity of the tweets extracted from the Twitts page is greater than the value expected.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedResult">A int value corresponding to a expected quantity of tweets in the collection.</param>
        public static void TweetListResultsQtyTest(List<Tweet> tweetList, int expectedResult)
        {
            int tweetQuantity = tweetList.Count;
            bool result = (tweetQuantity >= expectedResult);
                        
            WriteLine($"Quantity of results of Tweets scraped passed - {result}.");
        }

        /// <summary>
        /// This Test verifies if the content data extracted from the Tweets page really contains the key words expected.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedContent">A string containing the key words expected.</param>
        public static void TweetListContentTest(List<Tweet> tweetList, string expectedContent)
        {
            bool result=true;
            foreach (var twit in tweetList)
            {
                if (result == true && twit.Content.Contains(expectedContent))
                    result = true;
                else                    
                    result = false;
            }            
            WriteLine($"The Content test of results of Tweets scraped passed - {result}.");
        }

        /// <summary>
        /// This Test verifies if the UniqueId extracted from the Tweets page really contains this information. All the UniqueId contains "/status/" as part of the string.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        public static void TweetListUniqueIdTest(List<Tweet> tweetList)
        {
            bool result = true;
            foreach (var twit in tweetList)
            {
                if (result == true && (twit.UniqueId.Contains("/status/")))
                    result = true;
                else
                    result = false;
            }
            WriteLine($"The UniqueId Test of results of Tweets scraped passed - {result}.");            
        }
        
        /// <summary>
        /// This Test verifies if the likes quantity extracted from the Tweets page really is greater than the expected value.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedResult">A integer representing the quantity of min likes expected.</param>
        public static void TweetListLikesQtyTest(List<Tweet> tweetList, int expectedResult)
        {
            bool result = true;
            foreach (var twit in tweetList)
            {
                if (result == true && twit.Likes >= expectedResult)
                    result=true;
                else                    
                    result=false;                
            }
            WriteLine($"The Likes Quantity test of results of Tweets scraped passed - {result}.");
        }

        /// <summary>
        /// This Test verifies if the replies quantity extracted from the Tweets page really is greater than the expected value.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedResult">A integer representing the quantity of min replies expected.</param>
        public static void TweetListRepliesQtyTest(List<Tweet> tweetList, int expectedResult)
        {
            bool result = true;
            foreach (var twit in tweetList)
            {                
                if (result == true && twit.Replies >= expectedResult)
                    result=true;
                else
                    result=false;
            }
            WriteLine($"The Replies Quantity test of results of Tweets scraped passed - {result}.");
        }

        /// <summary>
        /// This Test verifies if the retweets quantity extracted from the Tweets page really is greater than the expected value.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedResult">A integer representing the quantity of min retweets expected.</param>
        public static void TweetListRetweetsQtyTest(List<Tweet> tweetList, int expectedResult)
        {
            bool result = true;
            foreach (var twit in tweetList)
            {
                if (result == true && twit.Retweets >= expectedResult)
                    result=true;
                else                    
                    result=false;                    
            }
            WriteLine($"The Likes Quantity test of results of Tweets scraped passed - {result}.");
        }        

        /// <summary>
        /// This Test verifies if the posted date of the Tweets page really matches with the since datetime is greater than the expected date.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedTimestamp">A string represented by a date since which the tweets are scraped.</param>
        public static void DateTimeSinceTest(List<Tweet> tweetList, string expectedTimestamp)
        {
            bool result=true;
            foreach (var twit in tweetList)
            {
                DateTime time = Methods.DateTimeConverter(twit.TimeStamp);
                DateTime expectedTime = Convert.ToDateTime(expectedTimestamp);
                                
                if (result == true && (time >= expectedTime))
                    result = true;
                else
                    result = false;                    
            }            
            WriteLine($"The Since test of results of Tweets scraped passed - {result}.");
        }

        /// <summary>
        /// This Test verifies if the posted date of the Tweets page really matches with the until datetime is lesser than the expected date.
        /// </summary>
        /// <param name="tweetList">A class System.Collections.Generic.List<Tweet>. Contains a list of tweets with the same characteristics extracted from the Twiits page.</param>
        /// <param name="expectedTimestamp">A string represented by a date until which the tweets are scraped.</param>
        public static void DateTimeUntilTest(List<Tweet> tweetList, string expectedTimestamp)
        {
            bool result=true;
            foreach (var twit in tweetList)
            {
                DateTime time = Methods.DateTimeConverter(twit.TimeStamp);
                DateTime expectedTime = Convert.ToDateTime(expectedTimestamp);
                
                if (result == true && (time >= expectedTime))
                    result = true;
                else
                    result = false;                    
            }            
            WriteLine($"The Until test of results of Tweets scraped passed - {result}.");
        }
    }
}
