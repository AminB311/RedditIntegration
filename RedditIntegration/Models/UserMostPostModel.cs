using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.Models
{
    public class UserMostPostModel
    {
        public string username { get; set; }
        public List<SubredditPostModel> posts { get; set; }
    }

}
