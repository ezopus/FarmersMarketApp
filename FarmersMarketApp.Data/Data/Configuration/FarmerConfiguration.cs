using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
	{
		private string AssemblyName = Path.GetFullPath(Assembly.GetCallingAssembly().FullName);
		private const string FarmerDataSet = @"..\FarmersMarketApp.Data\Datasets\farmers.json";
		private const string FarmerDataSetTests = @"..\..\..\..\FarmersMarketApp.Data\Datasets\farmers.json";
		public void Configure(EntityTypeBuilder<Farmer> builder)
		{
			var filePath = AssemblyName.Contains("FarmersMarketApp.Tests")
					? FarmerDataSetTests
					: FarmerDataSet;

			var farmers = LoadJsonData(filePath);

			//Add seed data
			builder.HasData(farmers);
		}

		private Farmer[] LoadJsonData(string filePath)
		{
			var importJson = File.ReadAllText(filePath);
			var importFarmer = JsonSerializer.Deserialize<ImportFarmerDto[]>(importJson);

			ICollection<Farmer> farmers = new HashSet<Farmer>();

			foreach (var farmer in importFarmer)
			{
				var newFarmer = new Farmer()
				{
					Id = farmer.Id,
					UserId = farmer.UserId,
					HasProducts = farmer.HasProducts,
					CompanyName = farmer.CompanyName,
					CompanyRegistrationNumber = farmer.CompanyRegistrationNumber,
					CompanyAddress = farmer.CompanyAddress,
					ImageUrl = string.IsNullOrEmpty(farmer.ImageUrl) ? "/img/no-image.png" : farmer.ImageUrl,
					IsApproved = farmer.IsApproved,
					IsDeleted = farmer.IsDeleted,
					DateApproved = string.IsNullOrEmpty(farmer.DateApproved) ? null : DateTime.ParseExact(farmer.DateApproved, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
				};

				farmers.Add(newFarmer);
			}

			return farmers.ToArray();
		}
	}
}
