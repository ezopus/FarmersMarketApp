using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
    public class FarmServices : IFarmService
    {
        private readonly FarmersMarketRepository repository;
        public FarmServices(FarmersMarketRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Farm>> GetFarmsAsync()
        {
            return await repository.All<Farm>().ToListAsync();
        }

        public async Task<Farm?> GetFarmByIdAsync(Guid id)
        {
            return await repository.All<Farm>().FirstOrDefaultAsync(f => f.Id == id);
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
