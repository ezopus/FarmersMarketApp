using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IUserService
	{
		Task<ApplicationUser?> GetCurrentUser(Guid userId);

		Task<bool> IsUserFarmer(Guid userId);
	}
}
