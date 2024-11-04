using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories;
using FarmersMarketApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
    public class ProductService : IProductService
    {
        private readonly FarmersMarketRepository repository;

        public ProductService(FarmersMarketRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await repository.AllReadOnly<Product>().ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await repository.All<Product>().FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<Product?> GetProductByName(string name)
        {
            return await repository.All<Product>().FirstOrDefaultAsync(pr => pr.Name == name);
        }

        public async Task<IEnumerable<Product>> GetProductsByFarmerId(Guid farmerId)
        {
            return await repository
                .All<Product>()
                .Where(pr => pr.Farmer.Id == farmerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByFarmId(Guid farmId)
        {
            return await repository
                .All<Product>()
                .Where(pr => pr.Farm.Id == farmId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await repository
                .All<Product>()
                .Where(pr => pr.CategoryId == categoryId)
                .ToListAsync(); ;
        }
    }
}
