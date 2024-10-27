using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class CategoryFarmerConfiguration : IEntityTypeConfiguration<CategoryFarmer>
    {
        public void Configure(EntityTypeBuilder<CategoryFarmer> builder)
        {
            builder.HasKey(pk => new { pk.CategoryId, pk.FarmerId });

            builder
                .HasOne(c => c.Category)
                .WithMany(cf => cf.CategoriesFarmers)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(f => f.Farmer)
                .WithMany(fc => fc.CategoriesFarmers)
                .HasForeignKey(f => f.FarmerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
