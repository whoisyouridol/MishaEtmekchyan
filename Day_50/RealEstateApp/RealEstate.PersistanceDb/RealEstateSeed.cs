using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.PersistanceDb
{
    public static class RealEstateSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using var scope = serviceProvider.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<RealEstateContext>();

            Migrate(database);
            Seed(database);
        }

        private static void Seed(RealEstateContext context)
        {
            var seeded = false;
            SeedBuildings(context, ref seeded);

            if (seeded)
                context.SaveChanges();
        }

        private static void Migrate(RealEstateContext context)
        {
            context.Database.Migrate(); 
        }

        private static void SeedBuildings(RealEstateContext context, ref bool seeded)
        {
            var buildings = new List<Domain.RealEstate>()
            {
                new Domain.RealEstate()
                {
                    Name = "Test Name 1",
                    BuiltYear = 1991,
                    Price = 933.22M
                },

                new Domain.RealEstate()
                {
                    Name = "Test Name 2",
                    BuiltYear = 2021,
                    Price = 1000_000M
                },
                new Domain.RealEstate()
                {
                    Name = "Test Name 3",
                    BuiltYear = 2010,
                    Price = 921.44M
                },
            };
            var counter = 0;
            foreach (var building in buildings)
            {
                if (context.RealEstates.AnyAsync(x => x.Id == building.Id).Result)
                {
                    continue;
                }
                else
                {
                    context.Add(building);
                    counter++;
                }
            }
            if (counter == buildings.Count) seeded = true;
            
        }

    }
}
