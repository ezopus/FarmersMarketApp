using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
	{
		private string AssemblyName = Path.GetFullPath(Assembly.GetCallingAssembly().FullName);
		private const string ProductOrdersDataSet = @"..\FarmersMarketApp.Data\Datasets\product-orders.json";
		private const string ProductOrdersDataSetTests = @"..\..\..\..\FarmersMarketApp.Data\Datasets\product-orders.json";
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

			var filePath = AssemblyName.Contains("FarmersMarketApp.Tests")
				? ProductOrdersDataSetTests
				: ProductOrdersDataSet;

			var productOrders = LoadJsonData(filePath);

			//Add seed data
			builder.HasData(productOrders);
		}

		private ProductOrder[] LoadJsonData(string filePath)
		{
			var importJson = File.ReadAllText(filePath);
			var importProductOrders = JsonSerializer.Deserialize<ImportProductOrderDto[]>(importJson);

			ICollection<ProductOrder> productOrders = new HashSet<ProductOrder>();

			foreach (var productOrderDto in importProductOrders)
			{
				foreach (var product in productOrderDto.Products)
				{
					var productOrder = new ProductOrder
					{
						OrderId = Guid.Parse(productOrderDto.OrderId),
						ProductId = Guid.Parse(product.ProductId),
						IsDeleted = product.IsDeleted,
						ProductQuantity = product.ProductQuantity,
						ProductPriceAtTimeOfOrder = product.ProductPriceAtTimeOfOrder,
						ProductDiscountAtTimeOfOrder = product.ProductDiscountAtTimeOfOrder,
						FarmId = Guid.Parse(product.FarmId),
						Status = (Status)product.Status,
					};
					productOrders.Add(productOrder);
				}
			}

			return productOrders.ToArray();
		}
	}
}
