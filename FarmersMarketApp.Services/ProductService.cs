using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<ProductInfoViewModel>> GetProductsAsync()
        {
            return await repository
                .AllAsync<Product>()
                .Select(p => new ProductInfoViewModel()
                {
                    Name = p.Name,
                    Description = p.Description,
                    FarmId = p.FarmId.ToString(),
                    Farm = p.Farm,
                    FarmerId = p.FarmerId.ToString(),
                    Farmer = p.Farmer,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    DiscountPercentage = p.DiscountPercentage ?? 0,
                    UnitType = p.UnitType.ToString(),
                    Size = p.Size,
                    Quantity = p.Quantity,
                    Origin = p.Origin ?? "",
                    ImageUrl = p.ImageUrl ?? "",
                })
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await repository.AllAsync<Product>().FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<Product?> GetProductByName(string name)
        {
            return await repository.AllAsync<Product>().FirstOrDefaultAsync(pr => pr.Name == name);
        }

        public async Task<IEnumerable<Product>> GetProductsByFarmerId(Guid farmerId)
        {
            return await repository
                .AllAsync<Product>()
                .Where(pr => pr.Farmer.Id == farmerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByFarmId(Guid farmId)
        {
            return await repository
                .AllAsync<Product>()
                .Where(pr => pr.Farm.Id == farmId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await repository
                .AllAsync<Product>()
                .Where(pr => pr.CategoryId == categoryId)
                .ToListAsync(); ;
        }
    }
}
