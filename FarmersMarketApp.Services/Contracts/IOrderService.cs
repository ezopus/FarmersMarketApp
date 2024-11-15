using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.OrderViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IOrderService
	{
		Task<bool> AddToOrderAsync(string userId, string productId, int productAmount);

		Task<bool> RemoveFromOrderAsync(string userId, string orderId, string productId);

		Task<bool> RemoveAllProductsFromOrderAsync(string userId, string orderId);

		Task<IEnumerable<OrderProductsViewModel>?> GetOrdersByUserIdAsync(string userId);

		Task<OrderCheckoutViewModel?> GetOrderForCheckoutAsync(string userId, string orderId);

		Task<bool> ChangeOrderToPendingAsync(string orderId);

		Task<Order?> GetOrderByIdAsync(string orderId);

		Task<bool> AddDeliveryDetailsToOrderByIdAsync(string orderId, OrderCheckoutViewModel model);

		Task<OrderDetailsViewModel[]?> GetProductsForOrderByOrderIdAsync(string orderId);
	}
}
