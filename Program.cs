using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using static System.Console;
using APIBehaviorTest.Data;
using System.Collections.Generic;
using System.Linq;
using APIBehaviorTest.Services;
using APIBehaviorTest.Tests;


namespace APIBehaviorTest
{
    public static class Program
    {
        
        public static void Main(string[] args)
        {
            WriteLine("Beginning the Test...\n");

            #region Variables // Needs to be put in other place

            var searchStringsList = new string[10];
            var resultStringsList = new string[10];
            var tweetListList = new List<Tweet>[10];
            var expectedResultQty = new int[10];
            var testResult = new bool[10];
            var windowIdList = new string[10];
            var driverList = new IWebDriver[10];

            searchStringsList[0] = new("Olympics Brasil maxresults:25");
            searchStringsList[1] = new("SpaceX Splashdown until:2021-08-01 since:2021-04-01");
            searchStringsList[2] = new("AI from:@Mit");
            searchStringsList[3] = new("Dogs @netflix min_replies:50");
            searchStringsList[4] = new("PlayStation5 min_faves:1500");
            searchStringsList[5] = new("\"Crypto Currency\" (#ElonMusk) min_retweets:125");
            searchStringsList[6] = new("\"Formula One\" @landonorris #landonorris");

            resultStringsList[0] = new("");
            resultStringsList[1] = new("");
            resultStringsList[2] = new("");
            resultStringsList[3] = new("");
            resultStringsList[4] = new("");
            resultStringsList[5] = new("");
            resultStringsList[6] = new("");
            #endregion
            
            for (var index = 0; index <= 6; index++)
            {
                (driverList[index], windowIdList[index]) = OpenWindow(index);
            }
            // removed because not functioning (unfortunately). Not a problem of the API but of this test project.
            // Parallel.For(0, 5,
            //    index => {
            //        resultStringsList[index] = new (InsertSearchString(driver, firstWindowId, searchStringsList[index]));                   
            //    });
            
            // the for calls 7 requisitions at almost same time
            for (var index = 0; index <= 6; index++)
            {
                InsertSearchString(driverList[index], windowIdList[index], searchStringsList[index]);
            }
            // the scrap call itself, returning the Json string
            for (var index = 0; index <= 6; index++)
            {
                resultStringsList[index] = (ScrapData(driverList[index], windowIdList[index], searchStringsList[index]));
            }
            // not tested so far
            for (int i = 0; i<=6; i++)
            {
                var tweets = new List<Tweet>();
                tweets = Methods.DeserializeList(resultStringsList[i]);
                tweetListList[i] = tweets;
            }
            

            #region // Test calls 
            // Unique Id Tests
            BehaviorTests.TweetListUniqueIdTest(tweetListList[6]);            
            // Qty Test
            BehaviorTests.TweetListResultsQtyTest(tweetListList[0], 25);
            // Timestamp Tests
            BehaviorTests.DateTimeSinceTest(tweetListList[1], "2021-04-01");            
            BehaviorTests.DateTimeUntilTest(tweetListList[1], "2021-08-01");
            // Content Test
            BehaviorTests.TweetListContentTest(tweetListList[2], "AI");
            BehaviorTests.TweetListContentTest(tweetListList[2], "@Mit");
            // Replies Test
            BehaviorTests.TweetListRepliesQtyTest(tweetListList[3], 50);
            // Likes Test
            BehaviorTests.TweetListLikesQtyTest(tweetListList[4], 1500);   
            // Retweets Test
            BehaviorTests.TweetListRetweetsQtyTest(tweetListList[5], 150);
            #endregion

            // Quiting the drivers, closing the browsers, if not closed so far.
            for (var index = 0; index <= 6; index++)
            {
                driverList[index].Quit();
            }
            WriteLine("Press a key to close the console.");
            ReadKey();
        }    

        /// <summary>
        /// A Method to open a new window of the browser.  
        /// </summary>
        /// <param name="index">For index to scroll the Array data</param>
        /// <returns>A Tuple of a IWebDriver an the WindowId of the opened window.</returns>
        public static (IWebDriver, string) OpenWindow(int index)
        {   
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.WindowHandles.Count == 1 );
            
            driver.SwitchTo().Window(driver.WindowHandles.Last());
                            
            var windowId = driver.CurrentWindowHandle;
            return (driver, windowId);   
        }

        /// <summary>
        /// A Method to insert the Url of the Api and the search string.
        /// </summary>
        /// <param name="driver">Selenium IWebDriver driver</param>
        /// <param name="windowId">String that identifies the window of the browser. The Selenium driver needs this information to controll the window.</param>
        /// <param name="searchString">String containing the query to be used by the API into the twitters page.</param>        
        public static void InsertSearchString(IWebDriver driver, string windowId, string searchString)
        {
            driver.SwitchTo().Window(windowId);
            driver.Navigate().GoToUrl("https://localhost:44344/Api/" + searchString);   
        }

        /// <summary>
        /// Method to Scrap data from the twitter page.
        /// </summary>
        /// <param name="driver">Selenium IWebDriver driver</param>
        /// <param name="windowId">String that identifies the window of the browser. The Selenium driver needs this information to controll the window.</param>
        /// <param name="searchString">String containing the query to be used by the API into the twitters page.</param>
        /// <returns>A string containing a Json that needs to be deserialized into a list of Tweets </returns>
        public static string ScrapData(IWebDriver driver, string windowId, string searchString)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(180));
            wait.Until(driver => driver.FindElement(By.XPath("pre")).Displayed);   
            IWebElement element = driver.FindElement(By.XPath("pre"));
            string resultString = element.Text;
            driver.Close();
            return resultString;
        }
    }
}
