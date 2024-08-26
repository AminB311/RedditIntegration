using RedditIntegration.IServices;
using RedditIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.Services
{
    public class StatisticsCalculatorService : IStatisticsCalculatorService
    {
        /// <summary>
        /// Get subreddit post with most up votes 
        /// </summary>
        public SubredditPostModel GetMostUpVotes(List<SubredditPostModel> posts)
        {
            return posts.OrderByDescending(x => x.data.ups).FirstOrDefault();
        }

        /// <summary>
        /// Get subreddit user with most posts
        /// </summary>
        public UserMostPostModel GetMostUserPost(List<SubredditPostModel> posts)
        {
            return posts.GroupBy(x => x.data.author).OrderByDescending(x => x.Count()).Select(x => new UserMostPostModel
            {   
                username = x.Key,
                posts = x.ToList()
            }).FirstOrDefault();
        }

    }
}
