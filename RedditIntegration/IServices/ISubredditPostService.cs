using RedditIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.IServices
{
    public interface ISubredditPostService
    {
        /// <summary>
        /// Fetch subreddit posts
        /// </summary>
        Task<SubredditPostResp> Fetch(string token);
    }
}
