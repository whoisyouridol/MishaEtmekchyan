using AdminService.Abstractions;
using BackgroundJobService.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ValidateService.Abstractions;

namespace AdminService.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAdminService,AdminService.Implementations.AdminService>();
            services.AddTransient<IValidateService, ValidateService.Implementations.ValidateService>();

            services.AddScoped<IBackgroundJobService,BackgroundJobService.Implementations.BackgroundJobService>();
        }
    }
}
