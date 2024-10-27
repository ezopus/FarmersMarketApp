using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(pk => new { pk.OrderId, pk.ProductId });

            builder
                .HasOne(p => p.Product)
                .WithMany(pr => pr.ProductsOrders)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(o => o.Order)
                .WithMany(op => op.ProductsOrders)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
