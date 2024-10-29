using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Datasets.ImportDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class FarmConfiguration : IEntityTypeConfiguration<Farm>
    {
        private const string FarmDataSet = "../FarmersMarketApp.Data/Datasets/farms.json";
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder
                .HasOne(f => f.Farmer)
                .WithOne(f => f.Farm)
                .HasForeignKey<Farmer>()
                .OnDelete(DeleteBehavior.NoAction);

            var farms = LoadJsonData(FarmDataSet);

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
                    Id = Guid.NewGuid(),
                    Name = farm.Name,
                    Address = farm.Address,
                    City = farm.City,
                    Email = farm.Email,
                    PhoneNumber = farm.PhoneNumber,
                    OpenHours = TimeOnly.Parse(farm.OpenHours),
                    CloseHours = TimeOnly.Parse(farm.CloseHours),
                    IsOpen = farm.IsOpen,
                    FarmerId = Guid.Parse(farm.FarmerId),
                };

                farms.Add(newFarm);
            }

            return farms.ToArray();
        }
    }
}
