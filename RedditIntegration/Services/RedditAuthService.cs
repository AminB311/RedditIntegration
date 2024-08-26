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
    public class RedditAuthService : IRedditAuthService
    {
        /// <summary>
        /// Get bearer token from reddit auth api
        /// </summary>
        public async Task<RedditAuthModel> GetAccessToken()
        {
            return await ApiHelperService.PostApi("https://www.reddit.com/", "api/v1/access_token", JsonConvert.SerializeObject(new { grant_type = Constants.grantType }));
        }

    }
}
