using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedData());
        }

        private List<Category> SeedData()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Meat"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Dairy"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Grain"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Fats"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fruits"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Vegetables"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Sweets"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Fish"
                },
                new Category()
                {
                    Id = 9,
                    Name = "Eggs"
                },
                new Category()
                {
                    Id = 10,
                    Name = "Drinks"
                }
            };

            return categories;
        }
    }
}
