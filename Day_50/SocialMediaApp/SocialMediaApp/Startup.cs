using AdminService.Extensions;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.AuthenticationManager;
using SocialMediaApp.Infrastructure.Extensions;
using SocialMediaApp.Infrastructure.Mappings;
using SocialMediaApp.PersistanceDB.Seed;
using WorkWithDbService.Extensions;

namespace SocialMediaApp
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
            services.AddTransient<IAuthenticationManager, AuthenticationManager.AuthenticationManager>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidAudience = ""
                     //i stopped here. 16:51
                 };
             });



            services.AddRepositories();
            services.AddServices();
            services.RegisterMaps();
            services.AddControllers();
            services.AddDB(Configuration.GetConnectionString("DefaultConnection"));

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer(services =>
            {
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHangfireDashboard();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            UsersSeed.Initialize(app.ApplicationServices);
        }
    }
}
