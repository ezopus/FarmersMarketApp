using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder
				.HasOne(u => u.Customer)
				.WithMany(u => u.Orders)
				.HasForeignKey(u => u.CustomerId)
				.OnDelete(DeleteBehavior.NoAction);
			builder
				.HasOne(p => p.Payment)
				.WithOne(o => o.Order)
				.HasForeignKey<Payment>(p => p.OrderId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
