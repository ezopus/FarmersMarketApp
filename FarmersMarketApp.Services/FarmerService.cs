using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IRepository repository;
        private readonly IUserService userService;

        public FarmerService(IRepository repository, IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }
        public async Task<Guid> BecomeFarmerAsync(ApplicationUser user, FarmerBecomeViewModel model)
        {
            var newFarmer = new Farmer()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                CompanyName = model.CompanyName,
                CompanyAddress = model.CompanyAddress,
                CompanyRegistrationNumber = model.CompanyRegistrationNumber,
                AcceptsDeliveries = model.AcceptsDeliveries.Value,
                HasProducts = model.HasProducts,
            };

            user.IsFarmer = true;

            await repository.AddAsync<Farmer>(newFarmer);
            await repository.SaveChangesAsync();

            return newFarmer.Id;
        }

        public async Task<Guid> GetFarmerIdByUserId(Guid userId)
        {
            var farmer = await repository
                .AllReadOnly<Farmer>()
                .FirstOrDefaultAsync(f => f.UserId == userId);

            return farmer!.Id;
        }

    }
}
