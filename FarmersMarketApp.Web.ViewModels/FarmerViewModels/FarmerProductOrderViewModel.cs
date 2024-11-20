using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Web.ViewModels.FarmerViewModels
{
	public class FarmerProductOrderViewModel
	{
		public DateTime OrderDate { get; set; }
		public string OrderId { get; set; } = null!;
		public IEnumerable<ProductFarmerOrderViewModel> OrderProducts { get; set; } = new List<ProductFarmerOrderViewModel>();

		public string DeliveryName { get; set; } = null!;

		public string DeliveryAddress { get; set; } = null!;

		public string DeliveryCity { get; set; } = null!;

		public string DeliveryPhoneNumber { get; set; } = null!;

		public Status Status { get; set; }

	}
}
