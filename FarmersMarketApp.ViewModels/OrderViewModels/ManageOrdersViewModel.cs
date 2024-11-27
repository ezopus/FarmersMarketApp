namespace FarmersMarketApp.ViewModels.OrderViewModels
{
	public class ManageOrdersViewModel
	{
		public IEnumerable<OrderProductsViewModel> Orders { get; set; } = new List<OrderProductsViewModel>();

		public string DefaultText { get; set; } = string.Empty;

		public string TableId { get; set; } = string.Empty;

		public string Classes { get; set; } = string.Empty;
	}
}
