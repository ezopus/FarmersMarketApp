using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.ProductViewModels;
using Moq;
using System.Globalization;

namespace FarmersMarketApp.Tests
{
	[TestFixture]
	public class ProductServiceTests : BaseUnitTests
	{
		private IRepository repository;
		private Mock<IUserService> userService;
		private Mock<IFarmService> farmService;
		private Mock<IFarmerService> farmerService;
		private IProductService productService;

		[OneTimeSetUp]
		public void SetUp()
		{
			repository = new FarmersMarketRepository(contextMock);
			userService = new Mock<IUserService>();
			farmService = new Mock<IFarmService>();
			farmerService = new Mock<IFarmerService>();
			productService = new ProductService(repository);

			var farm = contextMock.Farms.FirstOrDefault();

			var firstProductId = Guid.NewGuid();
			var secondProductId = Guid.NewGuid();
			var thirdProductId = Guid.NewGuid();

			var products = new List<Product>()
			{
				new Product
				{
					Id = firstProductId,
					Name = "First product",
					Description = "Product description",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 1,
					ProductionDate = DateTime.ParseExact("01-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
					ExpirationDate = DateTime.ParseExact("31-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
					CategoryId = 1,
					Price = 1,
					HasDiscount = false,
					FarmId = farm!.Id,
					IsDeleted = false,
					DateAdded = DateTime.ParseExact("01-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
				},
				new Product
				{
					Id = secondProductId,
					Name = "Second product",
					Description = "Product description",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 1,
					ProductionDate = DateTime.ParseExact("01-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
					ExpirationDate = DateTime.ParseExact("31-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
					CategoryId = 2,
					Price = 2,
					HasDiscount = false,
					FarmId = farm.Id,
					IsDeleted = false,
					DateAdded = DateTime.ParseExact("11-12-2001", "dd-MM-yyyy", CultureInfo.InvariantCulture),
				},
				new Product
				{
					Id = thirdProductId,
					Name = "Third product",
					Description = "Product description",
					UnitType = (UnitType)1,
					Quantity = 1,
					NetWeight = 1,
					ProductionDate = DateTime.ParseExact("01-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
					ExpirationDate = DateTime.ParseExact("31-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
					CategoryId = 2,
					Price = 3,
					HasDiscount = false,
					FarmId = farm.Id,
					IsDeleted = true,
					DateAdded = DateTime.ParseExact("31-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture)
				},
			};

			contextMock.Products.AddRange(products);
			contextMock.SaveChanges();
		}

		[Test]
		public async Task GetAllProductsAsync_NoFilterParams_ReturnsAllProducts()
		{
			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				null,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));
		}

		[Test]
		public async Task GetAllProductsAsync_FilterByName_ValidString_ReturnsCorrectNumberOfProducts()
		{
			// Arrange
			var searchTerm = "first";

			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				searchTerm,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(1));
		}

		[Test]
		public async Task GetAllProductsAsync_FilterByName_MissingString_ReturnsNoProducts()
		{
			// Arrange
			var searchTerm = "invalid";
			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				searchTerm,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(0));
			Assert.That(result.Products, Is.Empty);
		}

		[Test]
		public async Task GetAllProductsAsync_FilterByCategory_ReturnsCorrectNumberOfProducts()
		{
			// Arrange
			var categoryId = 2;
			// Act
			var result = await productService.GetAllProductsAsync(
				categoryId,
				null,
				null,
				null,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(2));
		}

		[Test]
		public async Task GetAllProductsAsync_FilterByFarmId_ValidFarmId_ReturnsCorrectNumberOfProducts()
		{
			// Arrange
			var farmId = contextMock.Farms.FirstOrDefault().Id.ToString();

			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				farmId,
				null,
				null,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));
		}

		[Test]
		public async Task GetAllProductsAsync_FilterByFarmId_InvalidFarmId_ReturnsNoProducts()
		{
			// Arrange
			var farmId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				farmId,
				null,
				null,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.Products, Is.Empty);
			Assert.That(result.TotalProducts, Is.EqualTo(0));
		}

		[Test]
		public async Task GetAllProductsAsync_FilterByFarmerId_ValidFarmerId_ReturnsCorrectNumberOfProducts()
		{
			// Arrange
			var farmer = contextMock.Farmers.FirstOrDefault();

			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				farmer.Id.ToString(),
				null,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));

		}

		[Test]
		public async Task GetAllProductsAsync_FilterByFarmerId_InvalidFarmerId_ReturnsNoProducts()
		{
			// Arrange
			var farmerId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				farmerId,
				null,
				(ProductSorting)1,
				default,
				default);

			// Assert
			Assert.That(result.Products, Is.Empty);
			Assert.That(result.TotalProducts, Is.EqualTo(0));
		}

		[Test]
		public async Task GetAllProductsAsync_SortByPriceAscending_ReturnsCorrectOrder()
		{
			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				null,
				ProductSorting.PriceAscending,
				currentPage: 1,
				productsPerPage: 8);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));
			Assert.That(result.Products.First().Name.Contains("First"), Is.True);
		}

		[Test]
		public async Task GetAllProductsAsync_SortByPriceDescending_ReturnsCorrectOrder()
		{
			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				null,
				ProductSorting.PriceDescending,
				currentPage: 1,
				productsPerPage: 8);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));
			Assert.That(result.Products.First().Name.Contains("Third"), Is.True);
		}

		[Test]
		public async Task GetAllProductsAsync_SortByNewest_ReturnsCorrectOrder()
		{
			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				null,
				ProductSorting.Newest,
				currentPage: 1,
				productsPerPage: 8);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));
			Assert.That(result.Products.First().Name.Contains("Third"), Is.True);
		}

		[Test]
		public async Task GetAllProductsAsync_SortByOldest_ReturnsCorrectOrder()
		{
			// Act
			var result = await productService.GetAllProductsAsync(
				null,
				null,
				null,
				null,
				ProductSorting.Oldest,
				currentPage: 1,
				productsPerPage: 8);

			// Assert
			Assert.That(result.TotalProducts, Is.EqualTo(3));
			Assert.That(result.Products.First().Name.Contains("Second"), Is.True);
		}

		[Test]
		public async Task GetProductByIdAsync_ValidProductId_ReturnsCorrectProduct()
		{
			// Arrange
			var product = contextMock.Products.First();

			// Act
			var result = await productService.GetProductByIdAsync(product.Id.ToString());

			// Assert
			Assert.That(result.Id, Is.EqualTo(product.Id.ToString()));
		}

		[Test]
		public async Task GetProductByIdAsync_InvalidProductId_ReturnsNull()
		{
			// Arrange
			var invalidProductId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.GetProductByIdAsync(invalidProductId);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetProductToEditByIdAsync_ValidProductId_ReturnsCorrectProduct()
		{
			// Arrange
			var product = contextMock.Products.FirstOrDefault(p => p.Name.Contains("First"));

			// Act
			var result = await productService.GetProductToEditByIdAsync(product.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result!.Id, Is.EqualTo(product.Id.ToString()));
		}

		[Test]
		public async Task GetProductToEditByIdAsync_ValidProductIdButDeletedProduct_ReturnsNull()
		{
			// Arrange
			var product = contextMock.Products.First();
			product.IsDeleted = true;
			await contextMock.SaveChangesAsync();

			// Act
			var result = await productService.GetProductToEditByIdAsync(product.Id.ToString());

			// Assert
			Assert.That(result, Is.Null);

			// Cleanup
			product.IsDeleted = false;
			await contextMock.SaveChangesAsync();
		}

		[Test]
		public async Task GetProductToEditByIdAsync_InvalidProductId_ReturnsNull()
		{
			// Arrange
			var invalidProductId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.GetProductToEditByIdAsync(invalidProductId);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task CreateProductAsync_ValidData_ReturnsNewProductId()
		{
			// Arrange
			var farm = contextMock.Farms.First();
			var newProduct = new AddProductViewModel
			{
				Name = "New product",
				Description = "New description",
				UnitType = "1",
				Quantity = 1,
				NetWeight = 1,
				ProductionDate = "31-12-2024",
				ExpirationDate = "31-01-2025",
				CategoryId = 1,
				Price = 1,
				HasDiscount = false,
				DiscountPercentage = 0,
				Barcode = null,
				Origin = null,
				FarmId = farm.Id.ToString(),
			};

			// Act
			var result = await productService.CreateProductAsync(newProduct);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(Guid.TryParse(result, out var parsedResult), Is.True);

			// Cleanup
			await repository.DeleteAsync<Product>(Guid.Parse(result));
			await repository.SaveChangesAsync();
		}

		[Test]
		public async Task CreateProductAsync_InvalidData_ReturnsNull()
		{
			// Arrange
			var farm = contextMock.Farms.First();
			var newProduct = new AddProductViewModel
			{

			};

			// Act
			var result = await productService.CreateProductAsync(newProduct);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task UpdateEditedProductAsync_ValidData_ReturnsTrue()
		{
			// Arrange
			var product = contextMock.Products.FirstOrDefault(p => p.Name.Contains("First"));

			var productEdited = new AddProductViewModel()
			{
				Id = product.Id.ToString(),
				Name = "Edited product",
				Description = "Product description",
				UnitType = "1",
				Quantity = 1,
				NetWeight = 1,
				ProductionDate = "01-12-2024",
				ExpirationDate = "31-12-2024",
				CategoryId = 1,
				Price = 1,
				HasDiscount = false,
				FarmId = product.FarmId.ToString(),
			};

			// Act
			var result = await productService.UpdateEditedProductAsync(productEdited, null);
			var getEditedProduct = await productService.GetProductByIdAsync(product.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(getEditedProduct.Name, Is.EqualTo(productEdited.Name));

			// Cleanup
			product.Name = "First product";
			product.IsDeleted = false;
			await repository.SaveChangesAsync();
		}

		[Test]
		public async Task UpdateEditedProductAsync_InvalidProductId_ReturnsFalse()
		{
			// Arrange
			var product = contextMock.Products.FirstOrDefault(p => p.Name.Contains("First"));
			var productEdited = new AddProductViewModel()
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Invalid product",
				Description = "Product description",
				UnitType = "1",
				Quantity = 1,
				NetWeight = 1,
				ProductionDate = "01-12-2024",
				ExpirationDate = "31-12-2024",
				CategoryId = 1,
				Price = 1,
				HasDiscount = false,
				FarmId = "",
			};

			// Act
			var result = await productService.UpdateEditedProductAsync(productEdited, null);

			// Assert
			Assert.That(result, Is.False);
		}

		//TODO: figure out why this test doesn't pass when all tests are run
		//[Test]
		//public async Task UpdateEditedProductAsync_ProductIsDeleted_ReturnsFalse()
		//{
		//	// Arrange
		//	var product = contextMock.Products.FirstOrDefault(p => p.IsDeleted == true);
		//	var productEdited = new AddProductViewModel
		//	{
		//		Id = product.Id.ToString(),
		//		Name = "Deleted product",
		//		Description = "Deleted description",
		//		UnitType = "1",
		//		Quantity = 1,
		//		NetWeight = 1,
		//		ProductionDate = "01-01-2000",
		//		ExpirationDate = "02-02-2000",
		//		CategoryId = 1,
		//		Price = 1,
		//		DiscountPercentage = 0,
		//		FarmId = Guid.NewGuid().ToString(),
		//	};

		//	// Act
		//	var result = await productService.UpdateEditedProductAsync(productEdited, null);

		//	// Assert
		//	Assert.That(result, Is.False);
		//}

		[Test]
		public async Task UpdateEditedProductAsync_InvalidData_ReturnsFalse()
		{
			// Arrange
			var productEdited = new AddProductViewModel()
			{
				Id = Guid.NewGuid().ToString(),
			};

			// Act
			var result = await productService.UpdateEditedProductAsync(productEdited, null);


			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetProductsForDeletionByFarmIdAsync_ValidFarmId_ReturnsCorrectCountOfProducts()
		{
			// Arrange
			var farm = contextMock.Farms.First();

			// Act
			var result = await productService.GetProductsForDeletionByFarmIdAsync(farm.Id.ToString());

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(3));
		}

		[Test]
		public async Task GetProductsForDeletionByFarmIdAsync_InvalidFarmId_ReturnsZero()
		{
			// Arrange
			var invalidFarmId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.GetProductsForDeletionByFarmIdAsync(invalidFarmId);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task SetProductIsDeletedByIdAsync_ValidProductId_ReturnsTrue()
		{
			// Arrange
			var product = contextMock.Products.FirstOrDefault(p => p.IsDeleted == false);

			// Act
			var result = await productService.SetProductIsDeletedByIdAsync(product.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(product.IsDeleted, Is.True);

			// Cleanup
			product.IsDeleted = false;
			await repository.SaveChangesAsync();
		}

		[Test]
		public async Task SetProductIsDeletedByIdAsync_InvalidProductId_ReturnsFalse()
		{
			// Arrange
			var productId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.SetProductIsDeletedByIdAsync(productId);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task RestoreProductByIdAsync_ValidProductId_ReturnsTrue()
		{
			// Arrange
			var product = contextMock.Products.FirstOrDefault(p => p.IsDeleted == true);

			// Act
			var result = await productService.RestoreProductByIdAsync(product.Id.ToString());

			// Assert
			Assert.That(result, Is.True);
			Assert.That(product.IsDeleted, Is.False);

			// Cleanup
			product.IsDeleted = true;
			await repository.SaveChangesAsync();
		}

		[Test]
		public async Task RestoreProductByIdAsync_InvalidProductId_ReturnsFalse()
		{
			// Arrange
			var productId = Guid.NewGuid().ToString();

			// Act
			var result = await productService.RestoreProductByIdAsync(productId);

			// Assert
			Assert.That(result, Is.False);
		}


		[OneTimeTearDown]
		public void Dispose() => contextMock.Dispose();
	}
}
