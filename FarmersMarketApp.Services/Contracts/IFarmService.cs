using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IFarmService
    {
        Task<IEnumerable<FarmInfoViewModel>> GetFarmsAsync();

        Task<Farm?> GetFarmByIdAsync(Guid id);

        Task<IEnumerable<Farm>> GetFarmsByFarmerIdAsync(Guid farmerId);
    }
}
