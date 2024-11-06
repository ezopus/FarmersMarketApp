using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetCurrentUserByIdAsync(Guid userId);

        Task<bool> IsUserFarmerAsync(Guid userId);
    }
}
