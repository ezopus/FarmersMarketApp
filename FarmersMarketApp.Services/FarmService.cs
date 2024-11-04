using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
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
        public async Task<IEnumerable<Farm>> GetFarmsAsync()
        {
            return await repository.AllAsync<Farm>().ToListAsync();
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
