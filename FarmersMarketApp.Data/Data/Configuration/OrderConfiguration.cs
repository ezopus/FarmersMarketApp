using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		private string AssemblyName = Path.GetFullPath(Assembly.GetCallingAssembly().FullName);
		private const string OrderDataSet = @"..\FarmersMarketApp.Data\Datasets\orders.json";
		private const string OrderDataSetTests = @"..\..\..\..\FarmersMarketApp.Data\Datasets\orders.json";
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

			var filePath = AssemblyName.Contains("FarmersMarketApp.Tests")
				? OrderDataSetTests
				: OrderDataSet;

			var orders = LoadJsonData(filePath);

			//Add seed data
			builder.HasData(orders);
		}

		private Order[] LoadJsonData(string filePath)
		{
			var importJson = File.ReadAllText(filePath);
			var importOrders = JsonSerializer.Deserialize<ImportOrderDto[]>(importJson);

			ICollection<Order> orders = new HashSet<Order>();

			foreach (var orderDto in importOrders)
			{
				var order = new Order()
				{
					Id = Guid.Parse(orderDto.Id),
					CustomerId = Guid.Parse(orderDto.CustomerId),
					CreateDate = string.IsNullOrEmpty(orderDto.CreateDate) == false
						? DateTime.ParseExact(orderDto.CreateDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)
						: null,
					Status = (Status)orderDto.Status,
					PaymentId = string.IsNullOrEmpty(orderDto.PaymentId) == false
						? Guid.Parse(orderDto.PaymentId)
						: null,
					DeliveryAddress = orderDto.DeliveryAddress,
					DeliveryCity = orderDto.DeliveryCity,
					DeliveryFirstName = orderDto.DeliveryFirstName,
					DeliveryLastName = orderDto.DeliveryLastName,
					DeliveryPhoneNumber = orderDto.DeliveryPhoneNumber,
				};

				orders.Add(order);
			}

			return orders.ToArray();
		}
	}
}
