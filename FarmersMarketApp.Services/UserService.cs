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
        public async Task<ApplicationUser?> GetCurrentUser(Guid userId)
        {
            return await repository
                .AllAsync<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<bool> IsUserFarmer(Guid userId)
        {
            var currentUser = await repository.GetByIdAsync<ApplicationUser>(userId);
            return currentUser.IsFarmer;
        }
    }
}
