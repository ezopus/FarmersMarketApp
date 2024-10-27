using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Farm)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.FarmId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder
            //    .HasOne(f => f.Farmer)
            //    .WithMany(p => p.Products)
            //    .HasForeignKey(f => f.FarmerId)
            //    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
