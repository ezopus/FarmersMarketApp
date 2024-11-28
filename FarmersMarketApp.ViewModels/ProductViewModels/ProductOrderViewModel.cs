using FarmersMarketApp.Common.Enums;

namespace FarmersMarketApp.ViewModels.ProductViewModels
{
	public class ProductOrderViewModel
	{
		//this view model is for orders where products need to be visualized

		public required string Id { get; set; }
		public required string Name { get; set; }
		public required decimal PriceAtPurchase { get; set; }
		public int Amount { get; set; }
		public string? ImageUrl { get; set; }
		public decimal Discount { get; set; }
		public bool IsDeleted { get; set; }
		public Status Status { get; set; }

	}
}
