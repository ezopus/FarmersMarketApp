using FarmersMarketApp.Infrastructure.Data;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Tests.Mocks;
using System.Globalization;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

namespace FarmersMarketApp.Tests
{
	public class BaseUnitTests
	{
		protected ApplicationDbContext contextMock;

		[SetUp]
		public void SetUpBase()
		{
			contextMock = DatabaseMock.ContextInstance;
			SeedDatabase();
		}
		public void SeedDatabase()
		{
			var userOne = new ApplicationUser()
			{
				FirstName = "Jim",
				LastName = "Halpert",
				UserName = "jim@office.com",
				Id = Guid.NewGuid(),
				IsFarmer = false,
				EmailConfirmed = true,
			};

			var userTwo = new ApplicationUser()
			{
				FirstName = "Pam",
				LastName = "Halpert",
				UserName = "pam@office.com",
				Id = Guid.NewGuid(),
				IsFarmer = false,
				EmailConfirmed = true,
			};

			var userThree = new ApplicationUser()
			{
				FirstName = "Kevin",
				LastName = "Malone",
				UserName = "kevin@office.com",
				Id = Guid.NewGuid(),
				IsFarmer = true,
				EmailConfirmed = true,
			};

			var userFour = new ApplicationUser()
			{
				FirstName = "Michael",
				LastName = "Scott",
				UserName = "michael@office.com",
				Id = Guid.NewGuid(),
				IsFarmer = true,
				EmailConfirmed = true,
			};

			var userFive = new ApplicationUser()
			{
				FirstName = "Kelly",
				LastName = "Kapoor",
				UserName = "kelly@office.com",
				Id = Guid.NewGuid(),
				IsFarmer = true,
				EmailConfirmed = true,
			};

			var farmerOne = new Farmer()
			{
				Id = Guid.NewGuid(),
				UserId = userThree.Id,
				User = userThree,
				HasProducts = true,
				IsApproved = true,
				IsDeleted = false,
				CompanyName = "Kevin's company",
				CompanyAddress = "Scranton",
				CompanyRegistrationNumber = "123456789",
				DateApproved = DateTime.ParseExact("01-01-2024", DateTimeRequiredFormat, CultureInfo.InvariantCulture),
				ImageUrl = "",
			};

			var farmerTwo = new Farmer()
			{
				Id = Guid.NewGuid(),
				UserId = userFour.Id,
				User = userFour,
				HasProducts = true,
				IsApproved = true,
				IsDeleted = true,
				CompanyName = "Michael's company",
				CompanyAddress = "Scranton",
				CompanyRegistrationNumber = "987654321",
				DateApproved = DateTime.ParseExact("31-12-2023", DateTimeRequiredFormat, CultureInfo.InvariantCulture),
				ImageUrl = "",
			};

			var farmerThree = new Farmer()
			{
				Id = Guid.NewGuid(),
				UserId = userFive.Id,
				User = userFive,
				HasProducts = true,
				IsApproved = false,
				IsDeleted = true,
				CompanyName = "Kelly's company",
				CompanyAddress = "Scranton",
				CompanyRegistrationNumber = "112233445",
				DateApproved = DateTime.ParseExact("04-04-2024", DateTimeRequiredFormat, CultureInfo.InvariantCulture),
				ImageUrl = "",
			};

			var farmOne = new Farm()
			{
				Id = Guid.NewGuid(),
				Name = "Kevin's farm",
				IsDeleted = false,
				OpenHours = TimeOnly.Parse("09:00"),
				CloseHours = TimeOnly.Parse("18:00"),
				Address = "Scranton",
				City = "Scranton",
				IsOpen = true,
			};

			var farmTwo = new Farm()
			{
				Id = Guid.NewGuid(),
				Name = "Michael's farm",
				IsDeleted = false,
				OpenHours = TimeOnly.Parse("09:00"),
				CloseHours = TimeOnly.Parse("18:00"),
				Address = "Scranton",
				City = "Scranton",
				IsOpen = true,
			};

			var farmThree = new Farm()
			{
				Id = Guid.NewGuid(),
				Name = "Michael's deleted farm",
				IsDeleted = true,
				OpenHours = TimeOnly.Parse("09:00"),
				CloseHours = TimeOnly.Parse("18:00"),
				Address = "Scranton",
				City = "Scranton",
				IsOpen = true,
			};

			var farmerFarmOne = new FarmerFarm()
			{
				FarmId = farmOne.Id,
				FarmerId = farmerOne.Id,
			};

			var farmerFarmTwo = new FarmerFarm()
			{
				FarmId = farmTwo.Id,
				FarmerId = farmerTwo.Id,
			};

			var farmerFarmThree = new FarmerFarm()
			{
				FarmId = farmThree.Id,
				FarmerId = farmerTwo.Id,
			};


			contextMock.Users.Add(userOne);
			contextMock.Users.Add(userTwo);
			contextMock.Users.Add(userThree);
			contextMock.Users.Add(userFour);
			contextMock.Users.Add(userFive);

			contextMock.Farmers.Add(farmerOne);
			contextMock.Farmers.Add(farmerTwo);
			contextMock.Farmers.Add(farmerThree);

			contextMock.Farms.Add(farmOne);
			contextMock.Farms.Add(farmTwo);
			contextMock.Farms.Add(farmThree);

			farmerOne.FarmersFarms.Add(farmerFarmOne);
			farmerTwo.FarmersFarms.Add(farmerFarmTwo);
			farmerThree.FarmersFarms.Add(farmerFarmThree);

			contextMock.SaveChanges();
		}

		[TearDown]
		public void TearDownBase() => contextMock.Dispose();
	}
}
