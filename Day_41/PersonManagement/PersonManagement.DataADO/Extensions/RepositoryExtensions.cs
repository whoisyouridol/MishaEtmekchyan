using MailService;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Data;
using PersonManagement.DataADO.Implementations;

namespace PersonManagement.DataADO.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMailService, MailService.Implementations.MailService>();
        }
    }
}
