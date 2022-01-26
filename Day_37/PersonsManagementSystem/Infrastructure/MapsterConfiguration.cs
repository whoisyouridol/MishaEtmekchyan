using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PersonsManagementSystem.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagementService.Models;

namespace PersonsManagementSystem.Infrastructure
{
    public static class MapsterConfiguration
    {
        public static void AddMapster(this IServiceCollection service)
        {
            TypeAdapterConfig<AddPersonDTO, PersonModel>
                .NewConfig();

            TypeAdapterConfig<PersonModel, GetPersonDTO>.
                NewConfig();
        }
    }
}