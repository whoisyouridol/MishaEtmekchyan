using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersistanceDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithDbService.Extensions
{
    public static class PersistanceDBExtensions
    {
        public static void AddDB(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

    }
}
