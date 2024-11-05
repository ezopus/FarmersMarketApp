namespace FarmersMarketApp.Web.ViewModels.FarmerViewModels
{
	public class FarmerBecomeViewModel
	{
		public Guid UserId { get; set; }

		public bool HasProducts { get; set; } = false;

		public bool? AcceptsDeliveries { get; set; } = null;

		public string? CompanyName { get; set; }

		public string? CompanyRegistrationNumber { get; set; }

		public string? CompanyAddress { get; set; }

		//TODO: Try to implement farmer category from the registration
		//public List<int> Categories { get; set; }
	}
}
