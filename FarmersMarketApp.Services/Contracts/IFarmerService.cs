using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IFarmerService
	{
		Task<Guid> BecomeFarmerAsync(ApplicationUser user, FarmerBecomeViewModel model);

	}
}
