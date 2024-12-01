using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;

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
			Assert.That(result.Count(), Is.EqualTo(2));
			Assert.That(result.First().Name, Is.EqualTo("Farm1"));
		}



	}

}
