using FarmersMarketApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmersMarketApp.Infrastructure.Data.Configuration
{
	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		private readonly IPasswordHasher<ApplicationUser> passwordHasher;

		public ApplicationUserConfiguration(IPasswordHasher<ApplicationUser> passwordHasher)
		{
			this.passwordHasher = passwordHasher;
		}
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			//Add seed data
			builder.HasData(SeedUser());
		}

		private ApplicationUser[] SeedUser()
		{
			var users = new List<ApplicationUser>();

			var userOne = new ApplicationUser()
			{
				Id = Guid.Parse("5510C3C2-99FD-4522-48CD-08DCF84E43E5"),
				UserName = "dwight@office.com",
				NormalizedUserName = "DWIGHT@OFFICE.COM",
				Email = "dwight@office.com",
				NormalizedEmail = "DWIGHT@OFFICE.COM",
				EmailConfirmed = true,
				FirstName = "Dwight",
				LastName = "Schrute",
				SecurityStamp = "618a1cc6-6284-4702-871c-1e58fe74f3f8",
				IsFarmer = true,
				ImageUrl = "/img/dwight.jpg",
			};

			userOne.PasswordHash = passwordHasher.HashPassword(userOne, "farmer");
			users.Add(userOne);

			var userTwo = new ApplicationUser()
			{
				Id = Guid.Parse("E2ECA858-9A52-4496-C029-08DCF857A1B7"),
				UserName = "kevin@office.com",
				NormalizedUserName = "KEVIN@OFFICE.COM",
				Email = "kevin@office.com",
				NormalizedEmail = "KEVIN@OFFICE.COM",
				EmailConfirmed = true,
				FirstName = "Kevin",
				LastName = "Bacon",
				SecurityStamp = "fd625ce4-2475-4d80-a609-df9d3ddf4598",
				IsFarmer = true,
				ImageUrl = "/img/kevin.jpg",
			};

			userTwo.PasswordHash = passwordHasher.HashPassword(userTwo, "farmer");
			users.Add(userTwo);

			var userThree = new ApplicationUser()
			{
				Id = Guid.Parse("DF1516DF-4501-475E-C02A-08DCF857A1B7"),
				UserName = "michael@office.com",
				NormalizedUserName = "MICHAEL@OFFICE.COM",
				Email = "michael@office.com",
				NormalizedEmail = "MICHAEL@OFFICE.COM",
				EmailConfirmed = true,
				FirstName = "Michael",
				LastName = "Scott",
				SecurityStamp = "288b8da7-b517-4f95-af28-3916b878adc1",
				IsFarmer = true,
				ImageUrl = "/img/michael.jpg",
			};

			userThree.PasswordHash = passwordHasher.HashPassword(userThree, "farmer");
			users.Add(userThree);

			var userFour = new ApplicationUser()
			{
				Id = Guid.Parse("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
				UserName = "jim@office.com",
				NormalizedUserName = "JIM@OFFICE.COM",
				Email = "jim@office.com",
				NormalizedEmail = "JIM@OFFICE.COM",
				EmailConfirmed = true,
				FirstName = "Jim",
				LastName = "Halpert",
				SecurityStamp = "08f6ec97-4269-466d-b207-47e30c651036"
			};

			userFour.PasswordHash = passwordHasher.HashPassword(userFour, "farmer");
			users.Add(userFour);


			var userFive = new ApplicationUser()
			{
				Id = Guid.Parse("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
				UserName = "creed@office.com",
				NormalizedUserName = "CREED@OFFICE.COM",
				Email = "creed@office.com",
				NormalizedEmail = "CREED@OFFICE.COM",
				EmailConfirmed = true,
				FirstName = "Creed",
				LastName = "Bratton",
				SecurityStamp = "a361e509-ad28-459e-b4c6-449937b3e998"
			};

			userFive.PasswordHash = passwordHasher.HashPassword(userFive, "farmer");
			users.Add(userFive);

			return users.ToArray();
		}
	}
}
