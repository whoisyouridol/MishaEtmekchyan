using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PersistanceDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace SocialMediaApp.PersistanceDB.Seed
{
    public static class UsersSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            Migrate(db);
            Seed(db);
        }
        private static void Migrate(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }
        private static void Seed(ApplicationDbContext context)
        {
            var seeded = false;
            SeedUsers(context, ref seeded);

            if (seeded)
                context.SaveChanges();
        }
        private static void SeedUsers(ApplicationDbContext context, ref bool seed)
        {
            var adminRole = new IdentityRole
            {
                Name = "AdminRole_" + Guid.NewGuid().ToString(),
            };

            var adminUser = new IdentityUser
            {
                UserName = "AdminUser_" + Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            var ph = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "admin_password");

            context.Roles.Add(adminRole);
            context.Users.Add(adminUser);
            context.SaveChanges();


            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = context.Users.SingleOrDefault(x => x.UserName == adminUser.UserName).Id,
                RoleId = context.Roles.SingleOrDefault(x => x.Name == adminRole.Name).Id
            });
            seed = true;
        }
    }
}