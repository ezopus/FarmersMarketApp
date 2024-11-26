namespace FarmersMarketApp.Web.ViewModels.AdminViewModels
{
	public class FarmInfoAdminViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;

		public string? ImageUrl { get; set; }

		public string Address { get; set; } = null!;

		public string City { get; set; } = null!;

		public bool IsDeleted { get; set; }
	}
}
