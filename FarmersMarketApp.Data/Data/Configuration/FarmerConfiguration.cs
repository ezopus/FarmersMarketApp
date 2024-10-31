﻿using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
    {
        private const string FarmerDataSet = "../FarmersMarketApp.Data/Datasets/farmers.json";
        public void Configure(EntityTypeBuilder<Farmer> builder)
        {
            var farmers = LoadJsonData(FarmerDataSet);

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
                    AcceptsDeliveries = farmer.AcceptsDeliveries,
                    CompanyName = farmer.CompanyName,
                    CompanyRegistrationNumber = farmer.CompanyRegistrationNumber,
                    CompanyAddress = farmer.CompanyAddress,
                };

                farmers.Add(newFarmer);
            }

            return farmers.ToArray();
        }
    }
}
