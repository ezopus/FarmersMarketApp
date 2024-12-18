﻿using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class FarmConfiguration : IEntityTypeConfiguration<Farm>
	{
		private string AssemblyName = Path.GetFullPath(Assembly.GetCallingAssembly().FullName);
		private const string FarmDataSet = @"..\FarmersMarketApp.Data\Datasets\farms.json";
		private const string FarmDataSetTests = @"..\..\..\..\FarmersMarketApp.Data\Datasets\farms.json";
		public void Configure(EntityTypeBuilder<Farm> builder)
		{
			var filePath = AssemblyName.Contains("FarmersMarketApp.Tests")
					? FarmDataSetTests
					: FarmDataSet;

			var farms = LoadJsonData(filePath);

			//Add seed data
			builder.HasData(farms);
		}

		private Farm[] LoadJsonData(string filePath)
		{
			var importJson = File.ReadAllText(filePath);
			var importFarm = JsonSerializer.Deserialize<ImportFarmDto[]>(importJson);

			ICollection<Farm> farms = new HashSet<Farm>();

			foreach (var farm in importFarm)
			{
				var newFarm = new Farm
				{
					Id = Guid.Parse(farm.Id),
					Name = farm.Name,
					Address = farm.Address,
					City = farm.City,
					Email = farm.Email,
					PhoneNumber = farm.PhoneNumber,
					OpenHours = TimeOnly.Parse(farm.OpenHours),
					CloseHours = TimeOnly.Parse(farm.CloseHours),
					IsOpen = farm.IsOpen,
					ImageUrl = string.IsNullOrWhiteSpace(farm.ImageUrl) ? "/img/no-image.png" : farm.ImageUrl,
				};

				farms.Add(newFarm);
			}

			return farms.ToArray();
		}
	}
}
