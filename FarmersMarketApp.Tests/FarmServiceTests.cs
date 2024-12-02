using FarmersMarketApp.Common.Enums;
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

		[OneTimeSetUp]
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

			//Cleanup
			contextMock.Remove(farm);
			await contextMock.SaveChangesAsync();
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

			//Cleanup
			var newFarm = await contextMock.Farms.FindAsync(Guid.Parse(result));
			contextMock.RemoveRange(newFarm.FarmersFarms);
			contextMock.Remove(newFarm);
			await contextMock.SaveChangesAsync();
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

		[Test]
		public async Task GetFarmNameAndIdForNewProductAsync_FarmsExist_ReturnsFarmOptions()
		{
			// Arrange
			var farmer = contextMock.Farmers.First();
			var farms = contextMock.Farms.Where(f => f.FarmersFarms.All(ff => ff.FarmerId == farmer.Id));

			// Act
			var result = await farmService.GetFarmNameAndIdForNewProductAsync(farmer.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(1));
			Assert.That(result.First().Name, Is.EqualTo(farms.First().Name));
		}


		[Test]
		public async Task GetOnlyFarmIdsByFarmerId_FarmsExist_ReturnsFarmIds()
		{
			// Arrange
			var farmer = contextMock.Farmers.First();
			var farms = contextMock.Farms.Where(f => f.FarmersFarms.All(ff => ff.FarmerId == farmer.Id));

			// Act
			var result = await farmService.GetOnlyFarmIdsByFarmerId(farmer.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(1));
			Assert.That(result.First(), Is.EqualTo(farms.First().Id.ToString()));
		}

		[Test]
		public async Task GetOnlyFarmIdsByFarmerId_NoFarmsExist_ReturnsNull()
		{
			// Arrange
			var farmerId = Guid.NewGuid();

			// Act
			var result = await farmService.GetOnlyFarmIdsByFarmerId(farmerId.ToString());

			// Assert
			Assert.That(result, Is.Empty);
		}

		[Test]
		public async Task RestoreFarmByFarmIdAsync_FarmExistsAndHasProducts_RestoresFarmAndProducts()
		{
			// Arrange
			var farmer = contextMock.Farmers.First();
			var farm = contextMock.Farms.FirstOrDefault(f => f.FarmersFarms.All(ff => ff.FarmerId == farmer.Id));
			var products = new List<Product>
			{
				new Product
				{
					Id = Guid.NewGuid(),
					IsDeleted = true,
					Name = "Restored product",
					ProductsOrders = null,
					CategoryId = 1,
					Price = 1,
					HasDiscount = false,
					DiscountPercentage = 0,
					FarmId = farm.Id,
					Description = "Meat product",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 100,
					ProductionDate = default,
					ExpirationDate = default,
					DateAdded = default,
				},
				new Product
				{
					Id = Guid.NewGuid(),
					IsDeleted = true,
					Name = "Restored product",
					ProductsOrders = null,
					CategoryId = 2,
					Price = 1,
					HasDiscount = false,
					DiscountPercentage = 0,
					FarmId = farm.Id,
					Description = "Dairy product",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 100,
					ProductionDate = default,
					ExpirationDate = default,
					DateAdded = default,
				}
			};

			contextMock.Products.AddRange(products);
			farm.IsDeleted = true;
			await contextMock.SaveChangesAsync();

			// Act
			var result = await farmService.RestoreFarmByFarmIdAsync(farm.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(farm.IsDeleted, Is.False);
			Assert.That(products.All(p => !p.IsDeleted), Is.True);

			//Cleanup
			contextMock.RemoveRange(products);
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task RestoreFarmByFarmIdAsync_FarmDoesNotExist_ReturnsFalse()
		{
			// Arrange
			var farmId = Guid.NewGuid();

			// Act
			var result = await farmService.RestoreFarmByFarmIdAsync(farmId.ToString());

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task SetFarmIsDeletedByFarmIdAsync_FarmExistsAndHasProducts_DeletesFarmAndProducts()
		{
			// Arrange
			var farmer = contextMock.Farmers.First();
			var farm = contextMock.Farms.FirstOrDefault(f => f.FarmersFarms.All(ff => ff.FarmerId == farmer.Id));
			var products = new List<Product>
			{
				new Product
				{
					Id = Guid.NewGuid(),
					IsDeleted = false,
					Name = "Restored product",
					ProductsOrders = null,
					CategoryId = 1,
					Price = 1,
					HasDiscount = false,
					DiscountPercentage = 0,
					FarmId = farm.Id,
					Description = "Meat product",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 100,
					ProductionDate = default,
					ExpirationDate = default,
					DateAdded = default,
				},
				new Product
				{
					Id = Guid.NewGuid(),
					IsDeleted = false,
					Name = "Restored product",
					ProductsOrders = null,
					CategoryId = 2,
					Price = 1,
					HasDiscount = false,
					DiscountPercentage = 0,
					FarmId = farm.Id,
					Description = "Dairy product",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 100,
					ProductionDate = default,
					ExpirationDate = default,
					DateAdded = default,
				}
			};

			contextMock.Products.AddRange(products);
			farm.IsDeleted = false;
			await contextMock.SaveChangesAsync();

			// Act
			var result = await farmService.SetFarmIsDeletedByFarmIdAsync(farm.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(farm.IsDeleted, Is.True);
			Assert.That(products.All(p => p.IsDeleted), Is.True);

			//Cleanup
			contextMock.RemoveRange(products);
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task SetFarmIsDeletedByFarmIdAsync_FarmDoesNotExist_ReturnsFalse()
		{
			// Arrange
			var farmId = Guid.NewGuid();

			// Act
			var result = await farmService.SetFarmIsDeletedByFarmIdAsync(farmId.ToString());

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetFarmNameAndIdForNewProductAsync_NoFarmsExist_ReturnsEmptyList()
		{
			// Arrange
			var farmerId = Guid.NewGuid();

			// Act
			var result = await farmService.GetFarmNameAndIdForNewProductAsync(farmerId.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Empty);
		}

		[OneTimeTearDown]
		public void DisposeDatabase() => contextMock.Dispose();

	}

}
