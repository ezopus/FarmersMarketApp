using FarmersMarketApp.ViewModels.FarmerViewModels;

namespace FarmersMarketApp.ViewModels.OrderViewModels
{
	public class ManageFarmerOrdersViewModel
	{
		public IEnumerable<FarmerProductOrderViewModel> Orders { get; set; } = new List<FarmerProductOrderViewModel>();

		public string DefaultText { get; set; } = string.Empty;

		public string TableId { get; set; } = string.Empty;

		public string Classes { get; set; } = string.Empty;

		public string TableName { get; set; } = string.Empty;
	}
}
