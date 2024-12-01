using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		private const string ProductDataSet = @"..\..\..\..\FarmersMarketApp.Data/Datasets/products.json";
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder
				.HasOne(p => p.Farm)
				.WithMany(p => p.Products)
				.HasForeignKey(p => p.FarmId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasData(SeedProducts(ProductDataSet));

		}

		private Product[] SeedProducts(string filePath)
		{
			var jsonString = File.ReadAllText(filePath);
			var importProduct = JsonSerializer.Deserialize<ImportProductDto[]>(jsonString);

			ICollection<Product> products = new HashSet<Product>();
			foreach (var product in importProduct)
			{
				var newFarm = new Product
				{
					Id = Guid.Parse(product.Id),
					Name = product.Name,
					Description = product.Description,
					UnitType = Enum.Parse<UnitType>(product.UnitType),
					Quantity = product.Quantity,
					NetWeight = product.NetWeight,
					Season = Enum.Parse<Season>(product.Season),
					ProductionDate = DateTime.ParseExact(product.ProductionDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None),
					ExpirationDate = DateTime.ParseExact(product.ExpirationDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None),
					CategoryId = product.CategoryId,
					Price = product.Price,
					HasDiscount = product.HasDiscount,
					DiscountPercentage = product.DiscountPercentage ?? 0.0m,
					FarmId = Guid.Parse(product.FarmId),
					Barcode = product.Barcode,
					ImageUrl = product.ImageUrl,
					Origin = product.Origin,
					IsDeleted = false,
					DateAdded = DateTime.ParseExact(product.DateAdded, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None)
				};

				products.Add(newFarm);
			}

			return products.ToArray();
		}
	}
}
