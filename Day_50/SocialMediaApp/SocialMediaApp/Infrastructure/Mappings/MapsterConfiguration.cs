using AdminService.ServiceModels;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaApp.Domain.Models;
using SocialMediaApp.RequestModels;

namespace SocialMediaApp.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<AccountRequestModel, AccountServiceModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<AccountServiceModel, ValidateAccountsServiceModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<AccountServiceModel, Account>
                .NewConfig()
                .TwoWays();
        }
    }
}
