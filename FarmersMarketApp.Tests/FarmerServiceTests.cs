using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.FarmerViewModels;

namespace FarmersMarketApp.Tests
{
	[TestFixture]
	public class FarmerServiceTests : BaseUnitTests
	{
		private IRepository repository;
		private IUserService userService;
		private IFarmService farmService;
		private IProductService productService;
		private IFarmerService farmerService;

		[SetUp]
		public void SetUp()
		{
			repository = new FarmersMarketRepository(contextMock);
			userService = new UserService(repository);
			productService = new ProductService(repository);
			farmService = new FarmService(repository, productService);
			farmerService = new FarmerService(repository, userService, farmService, productService);
		}

		//TODO: use only mocks where possible, remove IServices

		[Test]
		public async Task GetAllFarmersAsync_ReturnsAllFarmers()
		{
			// Act
			var result = await farmerService.GetAllFarmersAsync();

			// Assert
			Assert.That(result, Is.Not.Empty);
			Assert.That(result.Count(), Is.EqualTo(3));
		}

		[Test]
		public async Task GetAllActiveFarmersAsync_ReturnsAllActiveFarmers()
		{
			// Act
			var result = await farmerService.GetAllActiveFarmersAsync();

			// Assert
			Assert.That(result, Is.Not.Empty);
			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task BecomeFarmerAsync_ValidUser_CreatesFarmerAndReturnsId()
		{
			// Arrange
			var user = contextMock.Users.First(u => !u.IsFarmer);
			var model = new FarmerBecomeViewModel
			{
				CompanyName = "New Farmer Company",
				CompanyAddress = "New Address",
				CompanyRegistrationNumber = "1234567890"
			};

			// Act
			var result = await farmerService.BecomeFarmerAsync(user.Id.ToString(), model);
			var createdFarmer = contextMock.Farmers.FirstOrDefault(f => f.UserId == user.Id);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(createdFarmer, Is.Not.Null);
			Assert.That(createdFarmer.CompanyName, Is.EqualTo("New Farmer Company"));
			Assert.That(createdFarmer.CompanyAddress, Is.EqualTo("New Address"));
			Assert.That(createdFarmer.CompanyRegistrationNumber, Is.EqualTo("1234567890"));
			Assert.That(user.IsFarmer, Is.True);

			//Cleanup
			user.IsFarmer = false;
			contextMock.Remove(createdFarmer);
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task BecomeFarmerAsync_InvalidUser_ReturnsNull()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var model = new FarmerBecomeViewModel();

			// Act
			var result = await farmerService.BecomeFarmerAsync(userId, model);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetFarmerIdByUserIdAsync_ValidUserId_ReturnsFarmerId()
		{
			// Arrange
			var existingUser = contextMock.Users.First(u => u.IsFarmer);
			var expectedFarmerId = contextMock.Farmers.First(f => f.UserId == existingUser.Id).Id.ToString();

			// Act
			var result = await farmerService.GetFarmerIdByUserIdAsync(existingUser.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.EqualTo(expectedFarmerId));
		}

		[Test]
		public async Task GetFarmerIdByUserIdAsync_NonExistingUserId_ReturnsNull()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();

			// Act
			var result = await farmerService.GetFarmerIdByUserIdAsync(userId);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetFarmerIdByUserIdAsync_NullUserId_ReturnsNull()
		{
			// Act
			var result = await farmerService.GetFarmerIdByUserIdAsync(null);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetFarmerByIdAsync_ValidFarmerId_ReturnsFarmer()
		{
			// Arrange
			var farmer = contextMock.Farmers.First();

			// Act
			var result = await farmerService.GetFarmerByIdAsync(farmer.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(farmer.Id.ToString()));
			Assert.That(result.CompanyName, Is.EqualTo(farmer.CompanyName));
		}

		[Test]
		public async Task GetFarmerByIdAsync_InvalidFarmerId_ReturnsNull()
		{
			// Act
			var result = await farmerService.GetFarmerByIdAsync(Guid.NewGuid().ToString());

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetAllActiveFarmersAsync_ReturnsOnlyActiveFarmers()
		{
			// Act
			var result = await farmerService.GetAllActiveFarmersAsync();

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(result.All(f => !f.IsDeleted && f.IsApproved), Is.True);
				Assert.That(result.Count(), Is.EqualTo(1));
			});
		}

		[Test]
		public async Task ApproveFarmerByFarmerIdAsync_ValidFarmerId_ApprovesFarmer()
		{
			// Arrange
			var farmer = contextMock.Farmers.First(f => !f.IsApproved);

			// Act
			var result = await farmerService.ApproveFarmerByFarmerIdAsync(farmer.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(farmer.IsApproved, Is.True);
			Assert.That(farmer.DateApproved, Is.Not.Null);

			//Cleanup
			farmer.IsApproved = false;
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task ApproveFarmerByFarmerIdAsync_InvalidFarmerId_ReturnsFalse()
		{
			// Arrange
			var farmerId = Guid.NewGuid().ToString();

			// Act
			var result = await farmerService.ApproveFarmerByFarmerIdAsync(farmerId);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task SetFarmerIsDeletedByIdAsync_ValidFarmerId_SetsIsDeletedToTrue()
		{
			// Arrange
			var farmer = contextMock.Farmers.First(f => !f.IsDeleted);

			// Act
			var result = await farmerService.SetFarmerIsDeletedByIdAsync(farmer.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(farmer.IsDeleted, Is.True);

			//Cleanup
			farmer.IsDeleted = false;
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task SetFarmerIsDeletedByIdAsync_InvalidFarmerId_ReturnsFalse()
		{
			// Arrange
			var farmerId = Guid.NewGuid().ToString();

			// Act
			var result = await farmerService.SetFarmerIsDeletedByIdAsync(farmerId);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task RestoreFarmerByIdAsync_ValidFarmerId_SetsIsDeletedToFalse()
		{
			// Arrange
			var farmer = contextMock.Farmers.First(f => f.IsDeleted);

			// Act
			var result = await farmerService.RestoreFarmerByIdAsync(farmer.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(farmer.IsDeleted, Is.False);

			//Cleanup
			farmer.IsDeleted = true;
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task RestoreFarmerByIdAsync_InvalidFarmerId_ReturnsFalse()
		{
			// Arrange
			var farmerId = Guid.NewGuid().ToString();

			// Act
			var result = await farmerService.RestoreFarmerByIdAsync(farmerId);

			// Assert
			Assert.That(result, Is.False);
		}





		//Task<IEnumerable<FarmersForDropDown>> GetAllApprovedAndActiveFarmerNamesAndIdsAsync();




		//Task<bool> SetFarmerFarmsProductsIsDeletedByIdAsync(string farmerId);

		//Task<bool> RestoreFarmerFarmsProductsByIdAsync(string farmerId);
		//Task<IEnumerable<FarmerProductOrderViewModel>?> GetFarmerOpenOrdersAsync(string farmerId);


		[OneTimeTearDown]
		public void DisposeDatabase() => contextMock.Dispose();
	}
}
