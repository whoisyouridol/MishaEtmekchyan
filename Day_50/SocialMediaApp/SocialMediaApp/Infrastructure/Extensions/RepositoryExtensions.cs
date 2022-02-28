using Microsoft.Extensions.DependencyInjection;
using SocialMediaApp.Data;
using SocialMediaApp.Data.Abstractions;
using SocialMediaApp.DataEF.Repositories;

namespace SocialMediaApp.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<ITweetRepository,TweetRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        }

    }
}
