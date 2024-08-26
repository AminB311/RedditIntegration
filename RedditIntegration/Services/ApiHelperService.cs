using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditIntegration.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RedditIntegration.Services
{
    public class ApiHelperService
    {
        public static async Task<SubredditPostResp> GetApi(string BaseUrl, string endpoint, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(Constants.appName);
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonData = JObject.Parse(await response.Content.ReadAsStringAsync())["data"]["children"];
                    SubredditPostResp subredditPostResp = new SubredditPostResp();

                    subredditPostResp.header.used = Convert.ToDecimal(response.Headers.GetValues("x-ratelimit-used").FirstOrDefault());
                    subredditPostResp.header.remaining = Convert.ToDecimal(response.Headers.GetValues("x-ratelimit-remaining").FirstOrDefault());
                    subredditPostResp.header.reset = Convert.ToInt32(response.Headers.GetValues("x-ratelimit-reset").FirstOrDefault());

                    subredditPostResp.posts = JsonConvert.DeserializeObject<List<SubredditPostModel>>(jsonData.ToString());
                    return subredditPostResp;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }


        public static async Task<RedditAuthModel> PostApi(string BaseUrl, string endpoint, string JsonBody)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Constants.clientId}:{Constants.clientSecret}")));
                client.DefaultRequestHeaders.UserAgent.ParseAdd(Constants.appName);


                HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string> { { "grant_type", Constants.grantType }, });
                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<RedditAuthModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
