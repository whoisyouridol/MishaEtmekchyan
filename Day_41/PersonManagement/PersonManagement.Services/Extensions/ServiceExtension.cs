using Microsoft.Extensions.DependencyInjection;
using PersonManagement.DataADO.Extensions;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Implementations;
using MailService;
namespace PersonManagement.Services.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IUserService, UserService>();
            #region Repositories

            services.AddRepositories();

            #endregion
        }
    }
}
