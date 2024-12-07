using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class FarmerFarmConfiguration : IEntityTypeConfiguration<FarmerFarm>
	{
		private string AssemblyName = Path.GetFullPath(Assembly.GetCallingAssembly().FullName);
		private const string FarmerFarmDataSet = @"..\FarmersMarketApp.Data/Datasets/farmersfarms.json";
		private const string FarmerFarmDataSetTests = @"..\..\..\..\FarmersMarketApp.Data/Datasets/farmersfarms.json";
		public void Configure(EntityTypeBuilder<FarmerFarm> builder)
		{
			builder.HasKey(pk => new { pk.FarmId, pk.FarmerId });

			builder
				.HasOne(f => f.Farm)
				.WithMany(fr => fr.FarmersFarms)
				.HasForeignKey(f => f.FarmId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(f => f.Farmer)
				.WithMany(fr => fr.FarmersFarms)
				.HasForeignKey(f => f.FarmerId)
				.OnDelete(DeleteBehavior.NoAction);

			//Add seed data
			var filePath = AssemblyName.Contains("FarmersMarketApp.Tests")
					? FarmerFarmDataSetTests
					: FarmerFarmDataSet;
			var farmerFarms = LoadJsonData(filePath);

			builder.HasData(farmerFarms);
		}

		private FarmerFarm[] LoadJsonData(string filePath)
		{
			var importJson = File.ReadAllText(filePath);
			var importData = JsonSerializer.Deserialize<ImportFarmerFarmDto[]>(importJson);

			var farmerFarms = new HashSet<FarmerFarm>();

			foreach (var farmerFarmDto in importData)
			{
				if (string.IsNullOrEmpty(farmerFarmDto.FarmId)
					|| string.IsNullOrEmpty(farmerFarmDto.FarmerId))
				{
					continue;
				}
				var newFarmerFarm = new FarmerFarm()
				{
					FarmId = Guid.Parse(farmerFarmDto.FarmId),
					FarmerId = Guid.Parse(farmerFarmDto.FarmerId)
				};
				farmerFarms.Add(newFarmerFarm);
			}

			return farmerFarms.ToArray();
		}
	}
}
