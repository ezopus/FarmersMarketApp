namespace FarmersMarketApp.Web.ViewModels.FarmerViewModels
{
	public class FarmerInfoViewModel
	{
		public string Id { get; set; }
		public string FullName { get; set; }
		public required string CompanyName { get; set; }
		public required string CompanyAddress { get; set; }
		public string? ImageUrl { get; set; }
		public bool AcceptsDeliveries { get; set; }
		public bool? HasProducts { get; set; }
	}
}
