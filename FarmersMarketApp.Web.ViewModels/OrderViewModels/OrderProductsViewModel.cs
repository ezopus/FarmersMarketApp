using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.ViewModels.ProductViewModels;

namespace FarmersMarketApp.ViewModels.OrderViewModels
{
	public class OrderProductsViewModel
	{
		public string Id { get; set; } = string.Empty;

		public string CustomerId { get; set; } = string.Empty;

		public string CreateDate { get; set; } = string.Empty;

		public int TotalUnitItems => Products.Sum(pr => pr.Amount);

		public decimal TotalDiscount => Products.Sum(pr => pr.Discount * pr.Amount);

		public decimal TotalPrice => Products.Sum(pr => pr.PriceAtPurchase * pr.Amount);

		public Status Status { get; set; }

		public IEnumerable<ProductOrderViewModel> Products { get; set; } = new List<ProductOrderViewModel>();

		public bool IsDeleted { get; set; }
	}
}
