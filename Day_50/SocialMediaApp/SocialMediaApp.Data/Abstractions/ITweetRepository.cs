using SocialMediaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Data.Abstractions
{
    public interface ITweetRepository
    {
        Task<List<Tweet>> GetAllAsync();

        Task<Tweet> GetAsync(string id);

        Task CreateAsync(List<Tweet> tweets);

        Task CreateAsync(Tweet tweet);

        Task UpdateAsync(Tweet tweet);

        Task DeleteAsync(Tweet tweet);

        List<Tweet> GetTop10Tweets();
    }
}
