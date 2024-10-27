﻿using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class FarmConfiguration : IEntityTypeConfiguration<Farm>
    {
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder
                .HasOne(f => f.Farmer)
                .WithOne(f => f.Farm)
                .HasForeignKey<Farmer>()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
