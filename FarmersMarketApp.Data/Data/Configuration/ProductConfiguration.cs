using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		private const string ProductDataSet = "../FarmersMarketApp.Data/Datasets/products.json";
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder
				.HasOne(p => p.Farm)
				.WithMany(p => p.Products)
				.HasForeignKey(p => p.FarmId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(f => f.Farmer)
				.WithMany(p => p.Products)
				.HasForeignKey(f => f.FarmerId)
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
					Size = product.Size,
					Quantity = product.Quantity,
					NetWeight = product.NetWeight,
					ShippingWeight = product.ShippingWeight,
					Season = Enum.Parse<Season>(product.Season),
					ProductionDate = DateTime.Parse(product.ProductionDate),
					ExpirationDate = DateTime.Parse(product.ExpirationDate),
					CategoryId = product.CategoryId,
					Price = product.Price,
					HasDiscount = product.HasDiscount,
					DiscountPercentage = product.DiscountPercentage ?? 0.0m,
					FarmerId = Guid.Parse(product.FarmerId),
					FarmId = Guid.Parse(product.FarmId),
					Barcode = product.Barcode,
					ImageUrl = product.ImageUrl,
					Origin = product.Origin,
				};

				products.Add(newFarm);
			}

			return products.ToArray();
		}
	}
}
