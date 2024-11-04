using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
    public class FarmService : IFarmService
    {
        private readonly IRepository repository;
        public FarmService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<FarmInfoViewModel>> GetFarmsAsync()
        {
            return await repository
                .AllAsync<Farm>()
                .Select(f => new FarmInfoViewModel()
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    Address = f.Address,
                    PhoneNumber = f.PhoneNumber,
                    City = f.City,
                    CloseHours = f.CloseHours.ToString(),
                    OpenHours = f.OpenHours.ToString(),
                    Email = f.Email,
                    ImageUrl = f.ImageUrl,
                    IsOpen = f.IsOpen,
                    FarmersFarms = f.FarmersFarms,
                    Products = f.Products,
                })
                .ToListAsync();
        }

        public async Task<Farm?> GetFarmByIdAsync(Guid id)
        {
            return await repository.AllAsync<Farm>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Farm>> GetFarmsByFarmerIdAsync(Guid farmerId)
        {
            return await repository
                .AllReadOnly<Farm>()
                .Where(f => f.FarmersFarms.All(fm => fm.FarmerId == farmerId))
                .ToListAsync();
        }
    }
}
