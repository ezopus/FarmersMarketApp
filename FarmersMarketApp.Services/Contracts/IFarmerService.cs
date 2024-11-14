using FarmersMarketApp.Web.ViewModels.FarmerViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IFarmerService
	{
		Task<string?> BecomeFarmerAsync(string userId, FarmerBecomeViewModel model);

		Task<string?> GetFarmerIdByUserIdAsync(string userId);

		Task<FarmerInfoViewModel?> GetFarmerByIdAsync(string farmerId);

		Task<IEnumerable<FarmerInfoViewModel>> GetAllFarmersAsync();

		Task<bool> SetFarmerIsDeletedByIdAsync(string farmerId);
	}
}
