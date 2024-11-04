using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IFarmService
    {
        Task<IEnumerable<Farm>> GetFarmsAsync();

        Task<Farm?> GetFarmByIdAsync(Guid id);

        Task<IEnumerable<Farm>> GetFarmsByFarmerIdAsync(Guid farmerId);
    }
}
