namespace FarmersMarketApp.Web.ViewModels.FarmerViewModels
{
	public class FarmerInfoAdminViewModel
	{
		public required string Id { get; set; }
		public required string FullName { get; set; }
		public required string CompanyName { get; set; }
		public required string CompanyAddress { get; set; }
		public string? ImageUrl { get; set; }

		public bool IsDeleted { get; set; }
	}
}
