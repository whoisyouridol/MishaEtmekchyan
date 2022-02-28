using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceDB
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
