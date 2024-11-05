using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;

namespace FarmersMarketApp.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository repository;
		public UserService(IRepository repository)
		{
			this.repository = repository;
		}
		public async Task<ApplicationUser?> GetCurrentUser(Guid userId)
		{
			return repository
				.AllAsync<ApplicationUser>()
				.FirstOrDefault(u => u.Id == userId);
		}

		public async Task<bool> IsUserFarmer(Guid userId)
		{
			var currentUser = await repository.GetByIdAsync<ApplicationUser>(userId);
			return currentUser.IsFarmer;
		}
	}
}
