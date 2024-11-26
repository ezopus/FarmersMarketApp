namespace FarmersMarketApp.Web.ViewModels.AdminViewModels
{
	public class FarmerInfoAdminViewModel
	{
		public required string Id { get; set; }
		public required string FullName { get; set; }
		public required string CompanyName { get; set; }
		public required string CompanyAddress { get; set; }
		public required string CompanyRegistrationNumber { get; set; }
		public string? ImageUrl { get; set; }

		public bool IsDeleted { get; set; }
		public bool IsApproved { get; set; }

		public string DateApproved { get; set; } = string.Empty;
	}
}
