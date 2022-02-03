using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Data;
using PersonManagement.DataADO;

namespace PersonManagement.Web.Infrastracture.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
