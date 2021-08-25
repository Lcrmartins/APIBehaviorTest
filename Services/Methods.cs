using System;
using System.Collections.Generic;
using APIBehaviorTest.Data;
using Newtonsoft.Json;

namespace APIBehaviorTest.Services
{
    public static class Methods
    {
        /// <summary>
        /// Converts string to Datetime. Only in format yyyy-MM-dd.
        /// </summary>
        /// <param name="timestamp">String containing the full DateTime pattern, UTC.</param>
        /// <returns>It returns a datetime date format (yyyy-MM-dd). The hours, minutes and seconds and milliseconds are removed.</returns>
         public static DateTime DateTimeConverter(string timestamp)
        {
            if (timestamp is null)
                return default;
            if (timestamp == "")
                return default;
            if (timestamp.Length < 10)
                return default;
            string timestampDay = timestamp.Substring(0, 10);
            DateTime time = Convert.ToDateTime(timestampDay);
            return time;
        }

        /// <summary>
        /// This method deserialize the Json data from the API, extracted by this console test. 
        /// </summary>
        /// <param name="resultString">The resultString is the string to be deserialized. This method doesn't check if the string is well formatted. (To do.</param>
        /// <returns>The result is a List o objects of type Tweet.</returns>
        public static List<Tweet> DeserializeList(string resultString)
        {
            var tweets = new List<Tweet>();
            tweets = JsonConvert.DeserializeObject<List<Tweet>>(resultString);
            return tweets;
        }
    }
}