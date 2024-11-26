namespace FarmersMarketApp.Web.ViewModels.AdminViewModels
{
	public class ManageFarmersViewModel
	{
		public IEnumerable<FarmerInfoAdminViewModel> Farmers { get; set; } = new List<FarmerInfoAdminViewModel>();

		public string DefaultText { get; set; } = string.Empty;
	}
}
