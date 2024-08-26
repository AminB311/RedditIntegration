using RedditIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.IServices
{
    public interface IRedditAuthService
    {
        /// <summary>
        /// Get bearer token from reddit auth api
        /// </summary>
        Task<RedditAuthModel> GetAccessToken();
    }
}
