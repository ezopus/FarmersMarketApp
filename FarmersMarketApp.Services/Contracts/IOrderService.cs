using FarmersMarketApp.Web.ViewModels.OrderViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IOrderService
	{
		Task<bool> AddToOrderAsync(string userId, string productId, int productAmount);

		Task<bool> RemoveFromOrderAsync(string userId, string orderId, string productId);

		Task<bool> RemoveFromAllFromOrderAsync(string orderId, string userId);

		Task<IEnumerable<OrderProductsViewModel>?> GetOrdersByUserIdAsync(string userId);
	}
}
