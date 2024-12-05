using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;
using Moq;

namespace FarmersMarketApp.Tests
{
	public class OrderServiceTests : BaseUnitTests
	{
		private IRepository repository;
		private IUserService userService;
		private IProductService productService;
		private IOrderService orderService;
		private Mock<IRepository> repositoryMock;
		private Mock<IUserService> userServiceMock;
		private Mock<IProductService> productServiceMock;
		private Mock<IOrderService> orderServiceMock;

		[SetUp]
		public void Setup()
		{
			repository = new FarmersMarketRepository(contextMock);
			repositoryMock = new Mock<IRepository>();
			userService = new UserService(repository);
			userServiceMock = new Mock<IUserService>();
			productService = new ProductService(repository);
			productServiceMock = new Mock<IProductService>();
			orderService = new OrderService(repository, userService, productService);
		}


		//TODO: use only mocks, remove IServices
		[Test]
		public async Task AddToOrderAsync_ProductExists_ReturnsTrue()
		{
			// Arrange
			string userId = Guid.NewGuid().ToString();
			string productId = Guid.NewGuid().ToString();
			int productAmount = 1;

			productServiceMock
				.Setup(p => p.GetProductForOrderByProductIdAsync(productId))
				.ReturnsAsync(new Product
				{
					Id = Guid.NewGuid(),
					Name = "Product",
					Description = "Description",
					CategoryId = 1,
					Price = 1m,
					UnitType = (UnitType)0,
					Quantity = 0,
					NetWeight = 0,
					ProductionDate = default,
					ExpirationDate = default,
					HasDiscount = false,
					FarmId = default,
				});

			// Act
			var result = await orderService.AddToOrderAsync(userId, productId, productAmount);

			// Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task AddToOrderAsync_ProductDoesNotExist_ReturnsFalse()
		{
			// Arrange
			string userId = Guid.NewGuid().ToString();
			string productId = Guid.NewGuid().ToString();
			int productAmount = 1;

			// Act
			var result = await orderService.AddToOrderAsync(userId, productId, productAmount);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task RemoveFromOrderAsync_ProductExistsInOrder_ReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var productId = Guid.NewGuid().ToString();
			var customerId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid().ToString();
			var product = new Product
			{
				Id = Guid.Parse(productId),
				Name = "Product",
				Description = "Description",
				CategoryId = 1,
				Price = 1m,
				UnitType = (UnitType)0,
				Quantity = 0,
				NetWeight = 0,
				ProductionDate = default,
				ExpirationDate = default,
				HasDiscount = false,
				FarmId = default,
			};
			var productOrder = new ProductOrder()
			{
				OrderId = Guid.Parse(orderId),
				ProductId = product.Id,
				IsDeleted = false,
				ProductQuantity = 1,
				ProductPriceAtTimeOfOrder = 1m,
				ProductDiscountAtTimeOfOrder = 0,
				FarmId = Guid.Parse(farmId),
				Status = Status.Open
			};
			var productOrders = new List<ProductOrder>()
			{
				productOrder,
			};
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				CreateDate = null,
				DeliveryDate = null,
				PaymentId = null,
				Payment = null,
				ProductsOrders = productOrders,
				Status = Status.Open,
				DeliveryFirstName = null,
				DeliveryLastName = null,
				DeliveryAddress = null,
				DeliveryCity = null,
				DeliveryPhoneNumber = null
			};

			await repository.AddAsync(product);
			await repository.AddAsync(order);
			await repository.SaveChangesAsync();

			productServiceMock
				.Setup(p => p.GetProductForOrderByProductIdAsync(productId))
				.ReturnsAsync(product);

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(orderId))
				.ReturnsAsync((Order?)order);

			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrders.AsQueryable());


			// Act
			var result = await orderService.RemoveFromOrderAsync(userId, orderId, productId);

			// Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task RemoveFromOrderAsync_ProductNotInOrder_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var productId = Guid.NewGuid().ToString();

			// Act
			var result = await orderService.RemoveFromOrderAsync(userId, orderId, productId);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task RemoveAllProductsFromOrderAsync_OrderDoesNotExist_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(It.IsAny<Guid>()))
				.ReturnsAsync((Order?)null);

			// Act
			var result = await orderService.RemoveAllProductsFromOrderAsync(userId, orderId);

			// Assert
			Assert.That(result, Is.False);
		}

		//Task<bool> AddToOrderAsync(string userId, string productId, int productAmount);

		//Task<bool> RemoveFromOrderAsync(string userId, string orderId, string productId);

		//Task<bool> RemoveAllProductsFromOrderAsync(string userId, string orderId);

		//Task<IEnumerable<OrderProductsViewModel>?> GetOrdersByUserIdAsync(string userId);

		//Task<OrderCheckoutViewModel?> GetOrderForCheckoutAsync(string userId, string orderId);

		//Task<bool> ChangeOrderToPendingAsync(string orderId, string paymentId);

		//Task<Order?> GetOrderByIdAsync(string orderId);

		//Task<bool> AddDeliveryDetailsToOrderByIdAsync(string orderId, OrderCheckoutViewModel model);

		//Task<ProductOrderViewModel[]?> GetProductsForOrderByOrderIdAsync(string orderId);

		//Task<bool> CompleteProductOrderByOrderIdAsync(string orderId, IEnumerable<string> farmerFarms);
		//Task<bool> CancelProductOrderByOrderIdAsync(string orderId, IEnumerable<string> farmerFarms);
	}

}