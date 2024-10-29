using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUser());
        }

        private ApplicationUser[] SeedUser()
        {
            var users = new List<ApplicationUser>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Williams",
                    IsFarmer = false,
                    Email = "john@williams.com",

                }
            };

            return users.ToArray();
        }
    }
}
