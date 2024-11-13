using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.OrderViewModels;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

namespace FarmersMarketApp.Services
{
	public class OrderService : IOrderService
	{
		private readonly IRepository repository;
		private readonly IUserService userService;
		private readonly IProductService productService;
		public OrderService(IRepository repository,
			IUserService userService,
			IProductService productService)
		{
			this.repository = repository;
			this.userService = userService;
			this.productService = productService;
		}
		public async Task<bool> AddToOrderAsync(string userId, string productId, int productAmount)
		{
			//check to see if product exists
			var currentProduct = await productService.GetProductForOrderByProductIdAsync(productId);

			if (currentProduct == null)
			{
				return false;
			}

			//check to see if user has open order
			var currentOrder = await repository
				.AllAsync<Order>()
				.Where(o => o.CustomerId == Guid.Parse(userId) && o.OrderStatus == OrderStatus.Open)
				.FirstOrDefaultAsync();

			//if no open order exists, create a new one
			if (currentOrder == null)
			{
				currentOrder = new Order()
				{
					Id = Guid.NewGuid(),
					CustomerId = Guid.Parse(userId),
					CreateDate = DateTime.Now,
					OrderStatus = OrderStatus.Open,
				};

				//add new order to db
				await repository.AddAsync(currentOrder);
			}
			//get products in open order
			var productsInOpenOrder =
				await repository.AllAsync<ProductOrder>()
					.Where(o => o.OrderId == currentOrder.Id
								&& o.Order.OrderStatus == OrderStatus.Open)
					.ToListAsync();

			//perform check if product is already added to order
			//if it is added, just update quantity
			if (productsInOpenOrder.Any() && productsInOpenOrder.Any(pr => pr.ProductId == currentProduct.Id))
			{
				var currentProductAddedToOrderToUpdate =
					productsInOpenOrder.First(pr => pr.ProductId == currentProduct.Id);

				currentProductAddedToOrderToUpdate.ProductQuantity += productAmount;

			}
			//if product is not part of order, add it
			else
			{
				//add product to list of products in current order
				currentOrder.ProductsOrders.Add(new ProductOrder()
				{
					OrderId = currentOrder.Id,
					ProductId = currentProduct.Id,
					ProductQuantity = productAmount,
					ProductPriceAtTimeOfOrder = currentProduct.Price,
					FarmId = currentProduct.FarmId,
					FarmerId = currentProduct.FarmerId,
				});
			}

			await repository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> RemoveFromOrderAsync(string userId, string orderId, string productId)
		{
			//check to see if product exists
			var currentProduct = await productService.GetProductForOrderByProductIdAsync(productId);

			if (currentProduct == null)
			{
				return false;
			}

			//check to see if order is open
			var currentOrder = await repository.GetByIdAsync<Order>(Guid.Parse(orderId));
			if (currentOrder == null || currentOrder.OrderStatus != OrderStatus.Open)
			{
				return false;
			}

			//check to see if customer of order is the same as the one trying to remove the product
			if (currentOrder.CustomerId.ToString().ToLower() != userId.ToLower())
			{
				return false;
			}

			currentOrder.ProductsOrders =
				await repository.AllAsync<ProductOrder>().Where(o => o.OrderId == currentOrder.Id).ToListAsync();

			var productInOrder =
				currentOrder.ProductsOrders.FirstOrDefault(pr =>
					pr.ProductId.ToString().ToLower() == productId.ToLower());

			//check to see if product is part of current order
			if (productInOrder == null)
			{
				return false;
			}

			//if everything is correct, remove product from list of products in current order
			currentOrder.ProductsOrders.Remove(productInOrder);

			await repository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> RemoveAllProductsFromOrderAsync(string userId, string orderId)
		{
			//check to see if order exists and is open
			var currentOrder = await repository.GetByIdAsync<Order>(Guid.Parse(orderId));
			if (currentOrder == null || currentOrder.OrderStatus != OrderStatus.Open)
			{
				return false;
			}

			//check to see if customer of order is the same as the one trying to remove the product
			if (currentOrder.CustomerId.ToString().ToLower() != userId.ToLower())
			{
				return false;
			}

			//get all products in order
			currentOrder.ProductsOrders =
				await repository.AllAsync<ProductOrder>()
					.Where(o => o.OrderId == currentOrder.Id)
					.ToListAsync();

			//remove all products from order
			if (currentOrder.ProductsOrders.Any())
			{
				currentOrder.ProductsOrders.Clear();
			}

			await repository.DeleteAsync<Order>(currentOrder.Id);
			await repository.SaveChangesAsync();

			return true;
		}

		public async Task<IEnumerable<OrderProductsViewModel>?> GetOrdersByUserIdAsync(string userId)
		{
			var currentOrders = await repository
				.AllReadOnly<Order>()
				.Where(o => o.CustomerId == Guid.Parse(userId))
				.Select(o => new OrderProductsViewModel()
				{
					Id = o.Id.ToString(),
					CustomerId = o.CustomerId.ToString(),
					CreateDate = o.CreateDate.ToString("dd-MM-yyyy HH:mm"),
					OrderStatus = o.OrderStatus,
					Products = o.ProductsOrders.Select(pr => new ProductOrderViewModel()
					{
						Id = pr.ProductId.ToString(),
						Name = pr.Product.Name,
						PriceAtPurchase = pr.ProductPriceAtTimeOfOrder,
						Amount = pr.ProductQuantity,
						ImageUrl = pr.Product.ImageUrl,
						Discount = pr.Product.DiscountPercentage.HasValue
							? pr.Product.Price * (decimal)pr.Product.DiscountPercentage / 100
							: 0,
					}).ToList(),
				})
				.ToListAsync();

			return currentOrders;
		}

		public async Task<OrderCheckoutViewModel?> GetOrderForCheckoutAsync(string userId, string orderId)
		{
			//check to see if order exists and is open
			var currentOrder = await repository
				.AllReadOnly<Order>()
				.Where(o => o.Id == Guid.Parse(orderId))
				.Select(o => new OrderCheckoutViewModel()
				{
					Id = o.Id.ToString(),
					CustomerId = o.CustomerId.ToString(),
					CreateDate = o.CreateDate.ToString(DateTimeRequiredFormat),
					OrderStatus = o.OrderStatus,
					Products = o.ProductsOrders.Select(pr => new ProductOrderViewModel()
					{
						Id = pr.ProductId.ToString(),
						Name = pr.Product.Name,
						PriceAtPurchase = pr.ProductPriceAtTimeOfOrder,
						Amount = pr.ProductQuantity,
						ImageUrl = pr.Product.ImageUrl,
						Discount = pr.Product.DiscountPercentage.HasValue
							? pr.Product.Price * (decimal)pr.Product.DiscountPercentage / 100
							: 0,
					}).ToList(),
				})
				.FirstOrDefaultAsync();

			if (currentOrder == null || currentOrder.OrderStatus != OrderStatus.Open)
			{
				return null;
			}

			//check to see if customer of order is the same as the one trying to checkout
			if (currentOrder.CustomerId.ToString().ToLower() != userId.ToLower())
			{
				return null;
			}

			return currentOrder;
		}

		public async Task<bool> ChangeOrderToPendingAsync(string orderId)
		{
			var currentOrder = await repository.GetByIdAsync<Order>(Guid.Parse(orderId));

			if (currentOrder != null)
			{
				currentOrder.OrderStatus = OrderStatus.Pending;
				await repository.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<Order?> GetOrderByIdAsync(string orderId)
		{
			return await repository.GetByIdAsync<Order>(Guid.Parse(orderId));
		}

		public async Task<bool> AddDeliveryDetailsToOrderByIdAsync(string orderId, OrderCheckoutViewModel model)
		{
			var currentOrder = await repository.GetByIdAsync<Order>(Guid.Parse(orderId));

			if (currentOrder != null)
			{
				currentOrder.DeliveryFirstName = model.DeliveryFirstName;
				currentOrder.DeliveryLastName = model.DeliveryLastName;
				currentOrder.DeliveryAddress = model.DeliveryAddress;
				currentOrder.DeliveryCity = model.DeliveryCity;
				currentOrder.DeliveryPhoneNumber = model.DeliveryPhoneNumber;

				await repository.SaveChangesAsync();
				return true;
			}

			return false;
		}
	}
}
