using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.OrderViewModels;
using MockQueryable;
using Moq;
using System.Globalization;

namespace FarmersMarketApp.Tests
{
	public class OrderServiceTests
	{
		private IOrderService orderService;
		private Mock<IRepository> repositoryMock;
		private Mock<IUserService> userServiceMock;
		private Mock<IProductService> productServiceMock;

		[SetUp]
		public void Setup()
		{
			repositoryMock = new Mock<IRepository>();
			userServiceMock = new Mock<IUserService>();
			productServiceMock = new Mock<IProductService>();
			orderService = new OrderService(repositoryMock.Object, userServiceMock.Object, productServiceMock.Object);
		}

		[Test]
		public async Task AddToOrderAsync_ProductExists_ReturnsTrue()
		{
			// Arrange
			string userId = Guid.NewGuid().ToString();
			int productAmount = 1;
			var product = new Product
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
			};
			var order = new Order
			{
				CustomerId = Guid.Parse(userId),
			};

			productServiceMock
				.Setup(p => p.GetProductForOrderByProductIdAsync(It.IsAny<string>()))
				.ReturnsAsync(product);
			repositoryMock
				.Setup(r => r.All<Order>())
				.Returns(new List<Order> { order }.AsQueryable().BuildMock());
			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(new List<ProductOrder>().AsQueryable().BuildMock());

			// Act
			var result = await orderService.AddToOrderAsync(userId, product.Id.ToString(), productAmount);

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

			productServiceMock
				.Setup(p => p.GetProductForOrderByProductIdAsync(productId))
				.ReturnsAsync(product);

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(It.IsAny<Guid>()))
				.ReturnsAsync(order);

			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrders.AsQueryable().BuildMock());


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

		[Test]
		public async Task ChangeOrderToPendingAsync_ValidOrderId_ReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.Open,
			};
			var payment = new Payment()
			{
				Id = Guid.NewGuid(),
				CustomerId = Guid.Parse(userId),
				IsSuccessful = true,
				OrderId = Guid.Parse(orderId),
				PaymentAmount = 100,
				PaymentDate = DateTime.ParseExact("31-12-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture),
				PaymentType = PaymentType.CardPayment,
			};
			var productOrder = new List<ProductOrder>();

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(It.IsAny<Guid>()))
				.ReturnsAsync((Order?)order);
			repositoryMock
				.Setup(r => r.GetByIdAsync<Payment>(It.IsAny<Guid>()))
				.ReturnsAsync((Payment?)payment);
			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrder.AsQueryable().BuildMock());

			// Act
			var result = await orderService.ChangeOrderToPendingAsync(order.Id.ToString(), payment.Id.ToString());

			// Assert

			Assert.That(result, Is.True);
			Assert.That(order.Status, Is.EqualTo(Status.InProgress));
		}

		[Test]
		public async Task ChangeOrderToPendingAsync_InvalidOrderId_ReturnsFalse()
		{

			// Act
			var result = await orderService.ChangeOrderToPendingAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task ChangeOrderToPendingAsync_InvalidPaymentId_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.Open,
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(It.IsAny<Guid>()))
				.ReturnsAsync((Order?)order);

			// Act
			var result = await orderService.ChangeOrderToPendingAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetOrderByIdAsync_ValidOrderId_ReturnsCorrectOrderId()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.Open,
			};
			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(It.IsAny<Guid>()))
				.ReturnsAsync((Order?)order);


			// Act
			var result = await orderService.GetOrderByIdAsync(orderId);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(order.Id));
		}

		[Test]
		public async Task GetOrderByIdAsync_InvalidOrderId_ReturnsNull()
		{

			// Act
			var result = await orderService.GetOrderByIdAsync(Guid.NewGuid().ToString());

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task AddDeliveryDetailsToOrderByIdAsync_ValidOrderId_ReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.Open,
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(It.IsAny<Guid>()))
				.ReturnsAsync((Order?)order);
			var model = new OrderCheckoutViewModel
			{
				DeliveryFirstName = "John",
				DeliveryLastName = "Doe",
				DeliveryAddress = "Address",
				DeliveryCity = "City",
				DeliveryPhoneNumber = "0888123456"
			};

			// Act
			var result = await orderService.AddDeliveryDetailsToOrderByIdAsync(orderId, model);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(order.DeliveryFirstName, Is.EqualTo(model.DeliveryFirstName));
		}

		[Test]
		public async Task AddDeliveryDetailsToOrderByIdAsync_InvalidOrderId_ReturnsFalse()
		{
			// Arrange
			var model = new OrderCheckoutViewModel
			{
				DeliveryFirstName = "John",
				DeliveryLastName = "Doe",
				DeliveryAddress = "Address",
				DeliveryCity = "City",
				DeliveryPhoneNumber = "0888123456"
			};

			// Act
			var result = await orderService.AddDeliveryDetailsToOrderByIdAsync(Guid.NewGuid().ToString(), model);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetProductsForOrderByOrderIdAsync_ValidOrderId_ReturnsCorrectCountOfProducts()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.Open,
			};

			repositoryMock
				.Setup(r => r.AllReadOnly<ProductOrder>())
				.Returns(new List<ProductOrder>
				{
					new ProductOrder()
					{
						OrderId = order.Id,
						ProductId = Guid.NewGuid(),
						Product = new Product
						{
							Id = new Guid(),
							Name = "Product",
							CategoryId = 1,
							Description = "Description",
							UnitType = (UnitType)2,
							Quantity = 1,
							NetWeight = 1,
							ProductionDate = DateTime.Now,
							ExpirationDate = DateTime.Now,
							Price = 1,
							HasDiscount = false,
							FarmId = new Guid()
						}
					},
					new ProductOrder()
					{
						OrderId = order.Id,
						ProductId = Guid.NewGuid(),
						Product = new Product
						{
							Id = new Guid(),
							Name = "Product",
							CategoryId = 1,
							Description = "Description",
							UnitType = (UnitType)2,
							Quantity = 1,
							NetWeight = 1,
							ProductionDate = DateTime.Now,
							ExpirationDate = DateTime.Now,
							Price = 1,
							HasDiscount = false,
							FarmId = new Guid()
						}
					},
				}.AsQueryable().BuildMock());

			// Act 
			var result = await orderService.GetProductsForOrderByOrderIdAsync(orderId);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Length, Is.EqualTo(2));
		}

		[Test]
		public async Task GetProductsForOrderByOrderIdAsync_InvalidOrderId_ReturnsNull()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.Open,
			};

			repositoryMock
				.Setup(r => r.AllReadOnly<ProductOrder>())
				.Returns(new List<ProductOrder>().AsQueryable().BuildMock());

			// Act 
			var result = await orderService.GetProductsForOrderByOrderIdAsync(orderId);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task CompleteProductOrderByOrderIdAsync_ValidOrderId_HasProductsAndReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.InProgress,
			};
			var productOrders = new List<ProductOrder>
			{
				new ProductOrder()
				{
					OrderId = order.Id,
					ProductId = Guid.NewGuid(),
					FarmId = farmId,
					Status = Status.InProgress
				},
				new ProductOrder()
				{
					OrderId = order.Id,
					ProductId = Guid.NewGuid(),
					FarmId = farmId,
					Status = Status.InProgress,
				},
			};
			var farmerFarms = new List<string>
			{
				farmId.ToString(),
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(Guid.Parse(orderId)))
				.ReturnsAsync((Order?)order);

			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrders.AsQueryable().BuildMock());

			// Act 
			var result = await orderService.CompleteProductOrderByOrderIdAsync(orderId, farmerFarms);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(productOrders.All(pr => pr.Status == Status.Completed), Is.True);
		}

		[Test]
		public async Task CompleteProductOrderByOrderIdAsync_ValidOrderId_NoProductsReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.InProgress,
			};
			var productOrders = new List<ProductOrder>();

			var farmerFarms = new List<string>
			{
				farmId.ToString(),
			};

			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrders.AsQueryable().BuildMock());

			// Act 
			var result = await orderService.CompleteProductOrderByOrderIdAsync(orderId, farmerFarms);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task CompleteProductOrderByOrderIdAsync_InvalidOrderId_ReturnsFalse()
		{
			// Arrange
			var orderId = Guid.NewGuid().ToString();
			var farmerFarms = new List<string>
			{
				Guid.NewGuid().ToString(),
			};

			// Act 
			var result = await orderService.CompleteProductOrderByOrderIdAsync(orderId, farmerFarms);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task CancelProductOrderByOrderIdAsync_ValidOrderId_HasProductsAndReturnsTrue()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.InProgress,
			};
			var productOrders = new List<ProductOrder>
			{
				new ProductOrder()
				{
					OrderId = order.Id,
					ProductId = Guid.NewGuid(),
					FarmId = farmId,
					Status = Status.InProgress
				},
				new ProductOrder()
				{
					OrderId = order.Id,
					ProductId = Guid.NewGuid(),
					FarmId = farmId,
					Status = Status.InProgress,
				},
			};
			var farmerFarms = new List<string>
			{
				farmId.ToString(),
			};

			repositoryMock
				.Setup(r => r.GetByIdAsync<Order>(Guid.Parse(orderId)))
				.ReturnsAsync((Order?)order);

			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrders.AsQueryable().BuildMock());

			// Act 
			var result = await orderService.CancelProductOrderByOrderIdAsync(orderId, farmerFarms);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(productOrders.All(pr => pr.Status == Status.Cancelled), Is.True);
		}

		[Test]
		public async Task CancelProductOrderByOrderIdAsync_ValidOrderId_NoProductsReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid();
			var order = new Order
			{
				Id = Guid.Parse(orderId),
				CustomerId = Guid.Parse(userId),
				Status = Status.InProgress,
			};
			var productOrders = new List<ProductOrder>();

			var farmerFarms = new List<string>
			{
				farmId.ToString(),
			};

			repositoryMock
				.Setup(r => r.All<ProductOrder>())
				.Returns(productOrders.AsQueryable().BuildMock());

			// Act 
			var result = await orderService.CancelProductOrderByOrderIdAsync(orderId, farmerFarms);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task CancelProductOrderByOrderIdAsync_InvalidOrderId_ReturnsFalse()
		{
			// Arrange
			var orderId = Guid.NewGuid().ToString();
			var farmerFarms = new List<string>
			{
				Guid.NewGuid().ToString(),
			};

			// Act 
			var result = await orderService.CompleteProductOrderByOrderIdAsync(orderId, farmerFarms);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetOrdersByUserIdAsync_ValidUserId_HasOrders_ReturnsCorrectCountOfOrders()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid();
			var orders = new List<Order>()
			{
				new Order
				{
					Id = Guid.Parse(orderId),
					CustomerId = Guid.Parse(userId),
					Status = Status.InProgress,
					ProductsOrders = new List<ProductOrder>
					{
						new()
						{
							OrderId = Guid.Parse(orderId),
							ProductId = Guid.NewGuid(),
							Product = new Product
							{
								Id = new Guid(),
								Name = "Product",
								Description = "Description",
								UnitType = (UnitType)1,
								Quantity = 1,
								NetWeight = 1,
								ProductionDate = DateTime.Now,
								ExpirationDate = DateTime.Now,
								DateAdded = DateTime.Now,
								CategoryId = 1,
								Price = 1,
								HasDiscount = false,
								DiscountPercentage = 0,
								FarmId = new Guid(),
								IsDeleted = false,
							},
							FarmId = farmId,
							ProductPriceAtTimeOfOrder = 1,
							ProductQuantity = 1,
							ProductDiscountAtTimeOfOrder = 0,
							Status = Status.InProgress,
						},
						new()
						{
							OrderId = Guid.Parse(orderId),
							ProductId = Guid.NewGuid(),
							Product = new Product
							{
								Id = new Guid(),
								Name = "Product",
								Description = "Description",
								UnitType = (UnitType)1,
								Quantity = 1,
								NetWeight = 1,
								ProductionDate = DateTime.Now,
								ExpirationDate = DateTime.Now,
								DateAdded = DateTime.Now,
								CategoryId = 1,
								Price = 1,
								HasDiscount = false,
								DiscountPercentage = 0,
								FarmId = new Guid(),
								IsDeleted = false,
							},
							FarmId = farmId,
							ProductPriceAtTimeOfOrder = 1,
							ProductQuantity = 1,
							ProductDiscountAtTimeOfOrder = 0,
							Status = Status.InProgress,
						},
					},
				},
				new Order()
				{
					Id = Guid.NewGuid(),
					CustomerId = Guid.Parse(userId),
					Status = Status.Open,
					ProductsOrders = new List<ProductOrder>
					{
						new()
						{
							OrderId = Guid.Parse(orderId),
							ProductId = Guid.NewGuid(),
							Product = new Product
							{
								Id = new Guid(),
								Name = "Product",
								Description = "Description",
								UnitType = (UnitType)1,
								Quantity = 1,
								NetWeight = 1,
								ProductionDate = DateTime.Now,
								ExpirationDate = DateTime.Now,
								DateAdded = DateTime.Now,
								CategoryId = 1,
								Price = 1,
								HasDiscount = false,
								DiscountPercentage = 0,
								FarmId = new Guid(),
								IsDeleted = false,
							},
							FarmId = farmId,
							ProductPriceAtTimeOfOrder = 1,
							ProductQuantity = 1,
							ProductDiscountAtTimeOfOrder = 0,
							Status = Status.InProgress,
						},
					},
				}
			};


			repositoryMock
				.Setup(r => r.AllReadOnly<Order>())
				.Returns(orders.AsQueryable().BuildMock());

			userServiceMock
				.Setup(u => u.GetCurrentUserByIdAsync(userId))
				.ReturnsAsync(new ApplicationUser() { FirstName = "John", LastName = "Doe" });

			// Act 
			var result = await orderService.GetOrdersByUserIdAsync(userId);

			// Assert
			Assert.That(result, Is.Not.Empty);
			Assert.That(result.Count(), Is.EqualTo(2));
			Assert.That(result.Sum(r => r.Products.Count()), Is.EqualTo(3));
		}

		[Test]
		public async Task GetOrdersByUserIdAsync_ValidUserId_NoOrders_ReturnsCorrectCountOfOrders()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var orderId = Guid.NewGuid().ToString();
			var farmId = Guid.NewGuid();
			var orders = new List<Order>()
			{
				new Order
				{
					Id = Guid.Parse(orderId),
					CustomerId = Guid.Parse(userId),
					Status = Status.InProgress,
					ProductsOrders = new List<ProductOrder>
					{
					},
				},
			};

			repositoryMock
				.Setup(r => r.AllReadOnly<Order>())
				.Returns(orders.AsQueryable().BuildMock());
			userServiceMock
				.Setup(u => u.GetCurrentUserByIdAsync(userId))
				.ReturnsAsync(new ApplicationUser() { FirstName = "John", LastName = "Doe" });

			// Act 
			var result = await orderService.GetOrdersByUserIdAsync(userId);

			// Assert
			Assert.That(result, Is.Not.Empty);
			Assert.That(result.Sum(r => r.Products.Count()), Is.EqualTo(0));
		}

		[Test]
		public async Task GetOrdersByUserIdAsync_InvalidUserId_ReturnsCorrectCountOfOrders()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();

			// Act 
			var result = await orderService.GetOrdersByUserIdAsync(userId);

			// Assert
			Assert.That(result, Is.Empty);
		}
	}
}