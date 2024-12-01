using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.FarmViewModels;

namespace FarmersMarketApp.Tests
{
	[TestFixture]
	public class FarmServiceTests : BaseUnitTests
	{
		private IRepository repository;
		private IProductService productService;
		private IFarmService farmService;

		[SetUp]
		public void Setup()
		{
			repository = new FarmersMarketRepository(contextMock);
			productService = new ProductService(repository);
			farmService = new FarmService(repository, productService);
		}

		[Test]
		public async Task GetAllFarmsAsync_ShouldReturnAllFarms()
		{
			// Arrange & Act
			var result = await farmService.GetAllFarmsAsync();

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(3));
			Assert.That(result.First().Name, Is.EqualTo("Kevin's farm"));
		}

		[Test]
		public async Task GetActiveFarmsAsync_ShouldReturnOnlyActiveFarms()
		{
			// Arrange & Act
			var result = await farmService.GetActiveFarmsAsync();

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(2));
		}

		[Test]
		public async Task GetFarmByIdReadOnlyAsync_FarmExists_ReturnsFarm()
		{
			// Arrange
			var farmId = Guid.NewGuid();
			var farm = new Farm
			{
				Id = farmId,
				Name = "Farm1",
				Address = "Address1",
				City = "City1",
				IsDeleted = false,
				IsOpen = true,
			};

			contextMock.Farms.Add(farm);
			await contextMock.SaveChangesAsync();

			// Act
			var result = await farmService.GetFarmByIdReadOnlyAsync(farmId.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo("Farm1"));
		}

		[Test]
		public async Task GetFarmByIdReadOnlyAsync_FarmDoesNotExist_ReturnsNull()
		{
			// Arrange
			var farmId = Guid.NewGuid();


			// Act
			var result = await farmService.GetFarmByIdReadOnlyAsync(farmId.ToString());

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task AddNewFarmAsync_ValidData_AddsFarmAndReturnsId()
		{
			// Arrange
			var farmerId = Guid.NewGuid().ToString();
			var model = new AddFarmViewModel
			{
				Name = "NewFarm",
				Address = "Address",
				City = "City",
				Email = "email@farm.com",
				PhoneNumber = "123456789",
				ImageUrl = "image.jpg"
			};

			// Act
			var result = await farmService.AddNewFarmAsync(model, farmerId);

			// Assert
			Assert.That(result, Is.Not.Null);

		}

		[Test]
		public async Task EditFarmAsync_FarmExists_ReturnsTrue()
		{
			// Arrange
			var existingFarm = contextMock.Farms.First();
			var model = new AddFarmViewModel
			{
				Id = existingFarm.Id.ToString(),
				Name = "NewFarm",
				Address = "NewAddress",
				City = "NewCity",
			};


			// Act
			var result = await farmService.EditFarmAsync(model, null);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(existingFarm.Name, Is.EqualTo("NewFarm"));
			Assert.That(existingFarm.Address, Is.EqualTo("NewAddress"));
			Assert.That(existingFarm.City, Is.EqualTo("NewCity"));
		}

		[Test]
		public async Task EditFarmAsync_FarmDoesNotExist_ReturnsFalse()
		{
			// Arrange
			var model = new AddFarmViewModel { Id = Guid.NewGuid().ToString(), City = "", Address = "", Name = "" };

			// Act
			var result = await farmService.EditFarmAsync(model, null);

			// Assert
			Assert.That(result, Is.False);
		}

		[TearDown]
		public void DisposeDatabase() => contextMock.Dispose();

	}

}
