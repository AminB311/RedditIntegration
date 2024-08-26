using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedditIntegration.Models
{
    public class SubredditPostResp
    {
        public List<SubredditPostModel> posts { get; set; }=new List<SubredditPostModel>(); 
        public Header header { get; set; } = new Header();
    }

    public class SubredditPostModel
    {
        public string kind { get; set; }
        public Data data { get; set; }
    }

    public class Header
    {
        public decimal used { get; set; }
        public decimal remaining { get; set; }
        public int reset { get; set; }
    }

    public class Data
    {
        public string author { get; set; }
        public string title { get; set; }
        public int ups { get; set; }
        public string url { get; set; }
    }

}
