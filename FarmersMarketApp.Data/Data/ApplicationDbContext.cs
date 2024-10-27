using FarmersMarketApp.Infrastructure.Data.Configuration;
using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CategoryFarmerConfiguration());
            builder.ApplyConfiguration(new ProductOrderConfiguration());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Farmer> Farmers { get; set; }

        public DbSet<Farm> Farms { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryFarmer> CategoriesFarmers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductsOrders { get; set; }
    }
}
