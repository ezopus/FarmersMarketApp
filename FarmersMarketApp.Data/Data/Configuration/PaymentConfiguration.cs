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
	public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
	{
		private string AssemblyName = Path.GetFullPath(Assembly.GetCallingAssembly().FullName);
		private const string PaymentDataSet = @"..\FarmersMarketApp.Data\Datasets\payments.json";
		private const string PaymentDataSetTests = @"..\..\..\..\FarmersMarketApp.Data\Datasets\payments.json";
		public void Configure(EntityTypeBuilder<Payment> builder)
		{
			var filePath = AssemblyName.Contains("FarmersMarketApp.Tests")
				? PaymentDataSetTests
				: PaymentDataSet;

			var payments = LoadJsonData(filePath);

			//Add seed data
			builder.HasData(payments);
		}

		private Payment[] LoadJsonData(string filePath)
		{
			var importJson = File.ReadAllText(filePath);
			var importPayments = JsonSerializer.Deserialize<ImportPaymentDto[]>(importJson);

			ICollection<Payment> payments = new HashSet<Payment>();

			foreach (var paymentDto in importPayments)
			{
				var payment = new Payment()
				{
					Id = Guid.Parse(paymentDto.Id),
					CustomerId = Guid.Parse(paymentDto.CustomerId),
					PaymentAmount = paymentDto.PaymentAmount,
					PaymentType = (PaymentType)paymentDto.PaymentType,
					PaymentDate = DateTime.ParseExact(paymentDto.PaymentDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
					IsSuccessful = paymentDto.IsSuccessful,
					OrderId = Guid.Parse(paymentDto.OrderId)
				};

				payments.Add(payment);
			}

			return payments.ToArray();
		}

	}
}
