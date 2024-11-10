using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository repository;
		public UserService(IRepository repository)
		{
			this.repository = repository;
		}
		public async Task<ApplicationUser?> GetCurrentUserByIdAsync(string userId)
		{
			return await repository
				.AllAsync<ApplicationUser>()
				.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
		}

		public async Task<bool> IsUserFarmerAsync(string userId)
		{
			var currentUser = await repository.GetByIdAsync<ApplicationUser>(Guid.Parse(userId));

			if (currentUser == null)
			{
				return false;
			}

			return currentUser.IsFarmer;
		}
	}
}
