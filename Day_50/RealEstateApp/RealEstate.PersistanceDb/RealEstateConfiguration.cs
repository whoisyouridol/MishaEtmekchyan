using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.PersistanceDb
{
    public class RealEstateConfiguration : IEntityTypeConfiguration<Domain.RealEstate>
    {
        public void Configure(EntityTypeBuilder<Domain.RealEstate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BuiltYear).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(256);
        }
    }
}
