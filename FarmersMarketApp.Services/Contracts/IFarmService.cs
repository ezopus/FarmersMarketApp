using FarmersMarketApp.Web.ViewModels.FarmViewModels;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IFarmService
    {
        Task<IEnumerable<FarmInfoViewModel>> GetFarmsAsync();

        Task<FarmInfoViewModel?> GetFarmByIdAsync(Guid id);

        Task<IEnumerable<FarmInfoViewModel>> GetFarmsByFarmerIdAsync(Guid farmerId);
    }
}
