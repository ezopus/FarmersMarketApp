using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IUserService
	{
		Task<ApplicationUser?> GetCurrentUserByIdAsync(string userId);

		Task<bool> IsUserFarmerAsync(string userId);
	}
}
