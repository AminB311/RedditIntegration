using Newtonsoft.Json;
using RedditIntegration.IServices;
using RedditIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.Services
{
    public class SubredditPostService: ISubredditPostService
    {

        /// <summary>
        /// Fetch subreddit posts
        /// </summary>
        public async Task<SubredditPostResp> Fetch(string token)
        {            
            return await ApiHelperService.GetApi("https://oauth.reddit.com/", $"r/{Constants.subreddit}/new", token);
        }
    }
}
