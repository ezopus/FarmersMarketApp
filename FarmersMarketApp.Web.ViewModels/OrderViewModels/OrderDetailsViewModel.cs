namespace FarmersMarketApp.Web.ViewModels.OrderViewModels
{
	public class OrderDetailsViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		public decimal Discount { get; set; }

		public int Quantity { get; set; }

	}
}
