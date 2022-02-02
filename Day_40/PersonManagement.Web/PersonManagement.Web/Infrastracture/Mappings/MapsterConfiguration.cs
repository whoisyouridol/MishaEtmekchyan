using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.POCO;
using PersonManagement.Services.Models;
using PersonManagement.Web.Models.DTO;
using PersonManagement.Web.Models.Requests;

namespace PersonManagement.Web.Infrastracture.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
            //1. სტანდარტული მეპი

            //TypeAdapterConfig<PersonServiceModel, PersonDTO>
            //.NewConfig()
            //.TwoWays();

            //2. როცა არ ემთხვევა ფროფერთის სახელები ერთმანეთს

            //TypeAdapterConfig<PersonDTO, PersonServiceModel>
            //.NewConfig()
            //.TwoWays()
            //.Map(dest => dest.PersonIdentifier, src => src.Identifier);

            //3. სახელები ემთხვევა მაგრამ ტიპები არა , TwoWays ს არ მუშაობს (ლოგიკურია)
            //DTO->Service
            TypeAdapterConfig<PersonDTO, PersonServiceModel>
           .NewConfig()
           .Map(dest => dest.City, src => new CityServiceModel { Name = src.CityName })
           .Map(dest => dest.PersonIdentifier, src => src.Identifier);

            //3. Service->DTO 
            TypeAdapterConfig<PersonServiceModel, PersonDTO>
            .NewConfig()
            .Map(dest => dest.CityName, src => src.City.Name)
            .Map(dest => dest.Identifier, src => src.PersonIdentifier);


            TypeAdapterConfig<CreatePersonRequest, PersonServiceModel>
           .NewConfig()
           .Map(dest => dest.City, src => new CityServiceModel { Name = src.City })
           .Map(dest => dest.PersonIdentifier, src => src.Identifier);



            //4. City-ს რომ ერქვას CItyName(DTO-ში) ავტომატურად მიხვდება, რომ CityServiceModel კლასში 
            //მოძებნოს Name Property და თუ იპოვნის თავად გადაიყვანს CityName-ს(DTO) City.Name - ში (Service)

            //და  .Map(dest => dest.City, src => new CityServiceModel { Name = src.CityName })- ის დაწერა 
            //საჭირო აღარ იქნება 


            TypeAdapterConfig<PersonServiceModel, Person>
            .NewConfig()
            .TwoWays();
        }
    }
}
