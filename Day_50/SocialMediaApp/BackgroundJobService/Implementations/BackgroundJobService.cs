using BackgroundJobService.Abstractions;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SocialMediaApp.Data;
using SocialMediaApp.Data.Abstractions;
using SocialMediaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkWithDbService;
namespace BackgroundJobService.Implementations
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IAccountRepository _accountRepository;

        public BackgroundJobService(ITweetRepository tweetRepository, IAccountRepository accountRepository)
        {
            _tweetRepository = tweetRepository;
            _accountRepository = accountRepository;
        }

        private async Task<string> GetTweetsJson(string uri)
        {

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers
                .AuthenticationHeaderValue
            ("Bearer", "AAAAAAAAAAAAAAAAAAAAAKcZZQEAAAAAE0oD18FOBaUJWi%2FfKOmri2odyII%3D5X1bfqfJGAm1bEgO978FGWL7sd2NMLGqx1vs04UddVJ2UwDgF2");

            return await (await client.GetAsync(uri)).Content.ReadAsStringAsync();
        }

        private string ConfigureURI(string id)
        {
            var startTime = DateTime.UtcNow.AddMinutes(-5).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return $"https://api.twitter.com/2/users/{id}/tweets?tweet.fields=created_at&start_time={startTime}";
        }

        public async Task CheckFromTwitterAPI()
        {
                var accounts = await _accountRepository.GetAllAsync();
                var accountsIds = accounts.Select(x => x.Id).ToList();
                foreach (var id in accountsIds)
                {
                    string uri = ConfigureURI(id);

                    var json = await GetTweetsJson(uri);

                    var tweets = JsonConvert.DeserializeAnonymousType(json,
                        new
                        {
                            Data = new List<Tweet>(),
                            Meta = new { }
                        })
                        .Data;

                    if (tweets != null)
                    {
                        tweets.ForEach(x => x.AccountId = id);
                        await _tweetRepository.CreateAsync(tweets);
                    }
                }
        }

        public async Task SynchronizeAsync()
        {
            RecurringJob.AddOrUpdate(() => CheckFromTwitterAPI(), Cron.MinuteInterval(1));
            await Task.CompletedTask;
        }

    }
}