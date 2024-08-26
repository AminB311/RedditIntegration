// See https://aka.ms/new-console-template for more information
using RedditIntegration.IServices;
using RedditIntegration.Models;
using RedditIntegration.Services;

IRedditAuthService _redditAuthService = new RedditAuthService();
ISubredditPostService _subredditPostService = new SubredditPostService();
IStatisticsCalculatorService _statisticsCalculatorService = new StatisticsCalculatorService();

try
{
    RedditAuthModel redditAuthModel = await _redditAuthService.GetAccessToken();
    Task task = RunPeriodicTask(redditAuthModel.access_token);
    Console.ReadKey();
}
catch (Exception ex)
{//Global Error Handling, if prog crashes
    Console.WriteLine(ex.Message);
}

async Task RunPeriodicTask(string token)
{
    while (true)
    {
        SubredditPostResp resp = await _subredditPostService.Fetch(token);

        if (resp.header.remaining <= 1)
        {
            await Task.Delay(resp.header.reset * 2000);
        }
        else
        {
            SubredditPostModel mostUpVotes = _statisticsCalculatorService.GetMostUpVotes(resp.posts);
            UserMostPostModel mostUserPost = _statisticsCalculatorService.GetMostUserPost(resp.posts);

            Console.WriteLine($"Posts with most up votes. \nAuthor : {mostUpVotes.data.author}\nPost Title : {mostUpVotes.data.title}\nUrl : {mostUpVotes.data.url} \nPost Votes : {mostUpVotes.data.ups}");
            Console.WriteLine($"\nUsers with most posts. \nUser : {mostUserPost.username} \nPost Count : {mostUserPost.posts.Count}");
            Console.WriteLine("\n");

            await Task.Delay(2000);
        }


    }
}