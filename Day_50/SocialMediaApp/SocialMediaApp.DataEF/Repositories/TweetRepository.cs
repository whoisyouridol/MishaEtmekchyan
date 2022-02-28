using SocialMediaApp.Data.Abstractions;
using SocialMediaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataEF.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly IBaseRepository<Tweet> _repository;

        public TweetRepository(IBaseRepository<Tweet> repository)
        {
            _repository = repository;
        }
        public async Task<List<Tweet>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tweet> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public List<Tweet> GetTop10Tweets()
        {
            return  _repository.Table.OrderBy(x => x.Likes).Take(10).ToList();
        }
        public async Task CreateAsync(List<Tweet> tweets)
        {
            await _repository.CreateAsync(tweets);  
        }

        public async Task CreateAsync(Tweet tweet)
        {
            await _repository.CreateAsync(tweet);
        }

        public async Task DeleteAsync(Tweet tweet)
        {
            await _repository.DeleteAsync(tweet);
        }

        public async Task UpdateAsync(Tweet tweet)
        {
            await _repository.UpdateAsync(tweet);
        }
    }
}
