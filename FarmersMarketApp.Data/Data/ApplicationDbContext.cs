using FarmersMarketApp.Infrastructure.Data.Configuration;
using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Infrastructure.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			var passwordHasher = new PasswordHasher<ApplicationUser>();

			builder.ApplyConfiguration(new ApplicationUserConfiguration(passwordHasher));
			builder.ApplyConfiguration(new FarmerConfiguration());
			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.ApplyConfiguration(new FarmConfiguration());
			builder.ApplyConfiguration(new FarmerFarmConfiguration());
			builder.ApplyConfiguration(new ProductConfiguration());
			builder.ApplyConfiguration(new OrderConfiguration());
			builder.ApplyConfiguration(new ProductOrderConfiguration());
			builder.ApplyConfiguration(new PaymentConfiguration());
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Farmer> Farmers { get; set; }

		public DbSet<Farm> Farms { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Payment> Payments { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<ProductOrder> ProductsOrders { get; set; }
	}
}
