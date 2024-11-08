using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IFarmService
	{
		Task<IEnumerable<FarmInfoViewModel>> GetFarmsAsync();

		Task<FarmInfoViewModel?> GetFarmByIdReadOnlyAsync(Guid id);

		Task<AddFarmViewModel> GetFarmToEditByIdAsync(Guid id);

		Task<IEnumerable<FarmInfoViewModel?>> GetFarmsByFarmerIdAsync(Guid farmerId);

		Task<ICollection<string>> GetFarmIdsByFarmerId(Guid farmerId);

		Task<Farm> AddNewFarmAsync(AddFarmViewModel model, Guid farmerId);

		Task<bool> EditFarmAsync(AddFarmViewModel model);

		Task<List<AddProductFarmOptions>> GetFarmNameAndIdForNewProductAsync(Guid farmerId);

		Task<IEnumerable<AddProductFarmOptions>> GetThreeRandomFarmsForIndexCarousel();

	}
}
