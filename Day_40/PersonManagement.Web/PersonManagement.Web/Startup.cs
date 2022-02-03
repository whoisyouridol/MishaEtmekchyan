using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonManagement.Web.Infrastracture.Extensions;
using PersonManagement.Web.Infrastracture.Mappings;

using FluentValidation.AspNetCore;
using PersonManagement.DataADO;

namespace PersonManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(Configuration => Configuration.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddServices();
            services.RegisterMaps();
            services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseRequestCulture();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
