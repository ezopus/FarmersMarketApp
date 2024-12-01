using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;
using Moq;

namespace FarmersMarketApp.Tests
{
	[TestFixture]
	public class UserServiceTests
	{
		private Mock<IRepository> repositoryMock;
		private IUserService userService;

		[SetUp]
		public void Setup()
		{
			repositoryMock = new Mock<IRepository>();
			userService = new UserService(repositoryMock.Object);

			//var farmerUser = new ApplicationUser
			//{
			//	Id = Guid.NewGuid(),
			//	UserName = "kevin@office.com",
			//	IsFarmer = true,
			//	FirstName = "Kevin",
			//	LastName = "Malone"
			//};
			//var regularUser = new ApplicationUser
			//{
			//	Id = Guid.NewGuid(),
			//	UserName = "jim@office.com",
			//	FirstName = "Jim",
			//	LastName = "Halpert",
			//	IsFarmer = false,
			//};
			//repositoryMock
			//	.Setup(r => r.GetByIdAsync<ApplicationUser>(farmerUser.Id))
			//	.ReturnsAsync(farmerUser);
		}

		[Test]
		public async Task GetCurrentUserByIdAsync_UserExists_ReturnsUser()
		{
			// Arrange
			var farmerUser = new ApplicationUser
			{
				Id = Guid.NewGuid(),
				UserName = "kevin@office.com",
				IsFarmer = true,
				FirstName = "Kevin",
				LastName = "Malone"
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<ApplicationUser>(farmerUser.Id))
				.ReturnsAsync(farmerUser);

			// Act
			var result = await userService.GetCurrentUserByIdAsync(farmerUser.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.EqualTo(farmerUser));
			Assert.That(result.FirstName, Is.EqualTo(farmerUser.FirstName));
			repositoryMock.Verify(r => r.GetByIdAsync<ApplicationUser>(farmerUser.Id), Times.Once);
		}

		[Test]
		public async Task GetCurrentUserByIdAsync_UserDoesNotExist_ReturnsNull()
		{
			// Arrange
			var userId = Guid.NewGuid();

			repositoryMock
				.Setup(r => r.GetByIdAsync<ApplicationUser>(userId))
				.ReturnsAsync((ApplicationUser)null!);

			// Act
			var result = await userService.GetCurrentUserByIdAsync(userId.ToString());

			// Assert
			Assert.IsNull(result);
			repositoryMock.Verify(r => r.GetByIdAsync<ApplicationUser>(userId), Times.Once);
		}

		[Test]
		public async Task IsUserFarmerAsync_UserExistsAndIsFarmer_ReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var user = new ApplicationUser
			{
				Id = Guid.Parse(userId),
				IsFarmer = true,
				FirstName = "Kevin",
				LastName = "Malone"
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<ApplicationUser>(It.IsAny<Guid>()))
				.ReturnsAsync(user);

			// Act
			var result = await userService.IsUserFarmerAsync(userId);

			// Assert
			Assert.That(result, Is.True);
			repositoryMock.Verify(r => r.GetByIdAsync<ApplicationUser>(It.Is<Guid>(id => id == Guid.Parse(userId))), Times.Once);
		}

		[Test]
		public async Task IsUserFarmerAsync_UserExistsAndIsNotFarmer_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var user = new ApplicationUser
			{
				Id = Guid.Parse(userId),
				IsFarmer = false,
				FirstName = "Jim",
				LastName = "Halpert"
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<ApplicationUser>(It.IsAny<Guid>()))
				.ReturnsAsync(user);

			// Act
			var result = await userService.IsUserFarmerAsync(userId);

			// Assert
			Assert.That(result, Is.False);
			repositoryMock.Verify(r => r.GetByIdAsync<ApplicationUser>(It.Is<Guid>(id => id == Guid.Parse(userId))), Times.Once);
		}

		[Test]
		public async Task IsUserFarmerAsync_UserDoesNotExist_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();

			repositoryMock
				.Setup(r => r.GetByIdAsync<ApplicationUser>(It.IsAny<Guid>()))
				.ReturnsAsync((ApplicationUser)null!);

			// Act
			var result = await userService.IsUserFarmerAsync(userId);

			// Assert
			Assert.That(result, Is.False);
			repositoryMock.Verify(r => r.GetByIdAsync<ApplicationUser>(It.Is<Guid>(id => id == Guid.Parse(userId))), Times.Once);
		}
	}
}