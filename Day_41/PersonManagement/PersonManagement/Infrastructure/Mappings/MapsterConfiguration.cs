using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.DataADO.Models;
using PersonManagement.Domain.POCO;
using PersonManagement.Models.DTO;
using PersonManagement.Models.Request;
using PersonManagement.Services.Models;

namespace PersonManagement.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {

            //1.სტანდარტული მეპი , ორმხრივი მეპი 
            //TypeAdapterConfig<PersonDTO, PersonServiceModel>
            //.NewConfig().TwoWays()

            //.Ignore(dest=>dest.City); --ეს ხაზი City-ს რომ ჩავამატებ მერე


            //2.როცა არ ემთხვევა ფროერთიები
            //TypeAdapterConfig<PersonDTO, PersonServiceModel>
            //.NewConfig().TwoWays()
            //.Map(dest => dest.PersonIdentifier, src => src.Identifier);


            //3. როდესაც მნიშვნელობების გადაყვანა აგდმოყვანა სხვადასხვა ლგოიკით ხდება
            TypeAdapterConfig<PersonRequest, PersonServiceModel>
            .NewConfig()
            //.Map(dest => dest.City, src => new City { Name = src.City })
            .Map(dest => dest.PersonIdentifier, src => src.Identifier);


            TypeAdapterConfig<PersonPutRequest, PersonServiceModel>
             .NewConfig()
            //.Map(dest => dest.City, src => new City { Name = src.City })
            .Map(dest => dest.PersonIdentifier, src => src.Identifier);


            TypeAdapterConfig<PersonServiceModel, PersonDTO>
           .NewConfig()
           //.Map(dest => dest.City, src => src.City.Name)
           .Map(dest => dest.Identifier, src => src.PersonIdentifier);


            TypeAdapterConfig<PersonServiceModel, Person>
           .NewConfig()
           .TwoWays();

            //.Map(dest => dest.Age, src => $"Age is {DateTime.Now.Year - src.BirthDate.Year} years.");

            TypeAdapterConfig<UserServiceModel, User>
           .NewConfig()
           .TwoWays();

            TypeAdapterConfig<AccountCreateRequest, UserServiceModel>
          .NewConfig()
          .TwoWays();
            TypeAdapterConfig<UpdatePasswordRequest, UpdatePasswordServiceModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<UpdatePasswordRequest, User>
            .NewConfig()
            .TwoWays();
            TypeAdapterConfig<UpdatePasswordServiceModel, UpdateUserModel>
            .NewConfig()
            .TwoWays();
        }
    }
}
