using FarmersMarketApp.ViewModels.AdminViewModels;
using FarmersMarketApp.ViewModels.FarmerViewModels;


namespace FarmersMarketApp.Services.Contracts
{
	public interface IFarmerService
	{
		Task<string?> BecomeFarmerAsync(string userId, FarmerBecomeViewModel model);

		Task<string?> GetFarmerIdByUserIdAsync(string userId);

		Task<FarmerInfoViewModel?> GetFarmerByIdAsync(string farmerId);

		Task<IEnumerable<FarmersForDropDown>> GetAllApprovedAndActiveFarmerNamesAndIdsAsync();
		Task<IEnumerable<FarmerInfoAdminViewModel>> GetAllFarmersAsync();

		Task<IEnumerable<FarmerInfoViewModel>> GetAllActiveFarmersAsync();


		Task<bool> ApproveFarmerByFarmerIdAsync(string farmerId);
		Task<bool> SetFarmerIsDeletedByIdAsync(string farmerId);
		Task<bool> SetFarmerFarmsProductsIsDeletedByIdAsync(string farmerId);
		Task<bool> RestoreFarmerByIdAsync(string farmerId);
		Task<bool> RestoreFarmerFarmsProductsByIdAsync(string farmerId);


		Task<IEnumerable<FarmerProductOrderViewModel>?> GetFarmerOpenOrdersAsync(string farmerId);
		Task<bool> CompleteOrderByOrderIdAsync(string farmerId, string orderId);
		Task<bool> CancelOrderByOrderIdAsync(string farmerId, string orderId);
	}
}
