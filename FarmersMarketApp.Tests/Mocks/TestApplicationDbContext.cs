using FarmersMarketApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Tests.Mocks
{
	public class TestApplicationDbContext : ApplicationDbContext
	{
		public TestApplicationDbContext(DbContextOptions<TestApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//builder.ApplyConfiguration(new ApplicationUserConfiguration(passwordHasher));
			//builder.ApplyConfiguration(new FarmerConfiguration());
			//builder.ApplyConfiguration(new CategoryConfiguration());
			//builder.ApplyConfiguration(new FarmConfiguration());
			//builder.ApplyConfiguration(new FarmerFarmConfiguration());
			//builder.ApplyConfiguration(new ProductConfiguration());
			//builder.ApplyConfiguration(new OrderConfiguration());
			//builder.ApplyConfiguration(new ProductOrderConfiguration());
			//builder.ApplyConfiguration(new PaymentConfiguration());
		}
	}
}
