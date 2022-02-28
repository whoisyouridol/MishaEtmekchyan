using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RealEstate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RealEstate.PersistanceDb
{
    public class RealEstateContext : IdentityDbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options) { }


        public DbSet<Domain.RealEstate> RealEstates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealEstateContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
