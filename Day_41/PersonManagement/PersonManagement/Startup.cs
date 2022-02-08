using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonManagement.Common.Extensions;
using PersonManagement.Infrastructure.Mappings;
using PersonManagement.Extensions;
using FluentValidation.AspNetCore;
using PersonManagement.Services.Extensions;
using Microsoft.Extensions.Configuration;
using PersonManagement.DataADO.Models;
using Microsoft.AspNetCore.Authentication;
using PersonManagement.Infrastructure.Handler;
using MailService.Implementations;

namespace PersonManagement
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MailSettings>(_configuration.GetSection("MailSettings"));

            services.AddControllers().AddFluentValidation(configurationExpression => configurationExpression.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddHttpContextAccessor();
            services.AddServices();
            services.RegisterMaps();
            services.Configure<ConnectionStrings>(_configuration.GetSection(nameof(ConnectionStrings)));

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseRequestCulture();

            app.UseRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
