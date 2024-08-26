using RedditIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.IServices
{
    public interface IStatisticsCalculatorService
    {

        /// <summary>
        /// Get subreddit posts with most up votes 
        /// </summary>
        SubredditPostModel GetMostUpVotes(List<SubredditPostModel> posts);

        /// <summary>
        /// Get subreddit users with most posts
        /// </summary>
        UserMostPostModel GetMostUserPost(List<SubredditPostModel> posts);
    }
}
