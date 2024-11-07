using FarmersMarketApp.Web.ViewModels.FarmerViewModels;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IFarmerService
    {
        Task<Guid> BecomeFarmerAsync(Guid userId, FarmerBecomeViewModel model);

        Task<Guid?> GetFarmerIdByUserIdAsync(Guid userId);
        Task<FarmerInfoViewModel?> GetFarmerIdByAsync(string farmerId);

        Task<IEnumerable<FarmerInfoViewModel>> GetAllFarmersAsync();
    }
}
