namespace FarmersMarketApp.Web.ViewModels.ProductViewModels
{
	public class ProductFarmerOrderViewModel
	{
		public string ProductName { get; set; } = null!;

		public int ProductQuantity { get; set; }

		public decimal ProductPriceAtPurchase { get; set; }
	}
}
