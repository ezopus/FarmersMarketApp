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
                    Id = p.Id.ToString(),
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
                    ProductionDate = p.ProductionDate.ToString("dd-MM-yyyy"),
                    ExpirationDate = p.ProductionDate.ToString("dd-MM-yyyy"),
                })
                .ToListAsync();
        }

        public async Task<ProductInfoViewModel?> GetProductById(Guid id)
        {
            var product = await repository
                .AllAsync<Product>()
                .FirstOrDefaultAsync(pr => pr.Id == id);

            if (product == null)
            {
                return null;
            }

            var model = new ProductInfoViewModel()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                FarmId = product.FarmId.ToString(),
                Farm = product.Farm,
                FarmerId = product.FarmerId.ToString(),
                Farmer = product.Farmer,
                CategoryId = product.CategoryId,
                Price = product.Price,
                DiscountPercentage = product.DiscountPercentage ?? 0,
                UnitType = product.UnitType.ToString(),
                Size = product.Size,
                Quantity = product.Quantity,
                Origin = product.Origin ?? "",
                ImageUrl = product.ImageUrl ?? "",
                ProductionDate = product.ProductionDate.ToString("dd-MM-yyyy"),
                ExpirationDate = product.ProductionDate.ToString("dd-MM-yyyy"),
            };

            return model;
        }

        public async Task<Product?> GetProductByName(string name)
        {
            return await repository.AllAsync<Product>().FirstOrDefaultAsync(pr => pr.Name == name);
        }

        public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmerId(Guid farmerId)
        {
            return await repository
                .AllAsync<Product>()
                .Where(pr => pr.Farmer.Id == farmerId)
                .Select(pr => new ProductInfoViewModel()
                {
                    Id = pr.Id.ToString(),
                    Name = pr.Name,
                    Description = pr.Description,
                    FarmId = pr.FarmId.ToString(),
                    Farm = pr.Farm,
                    FarmerId = pr.FarmerId.ToString(),
                    Farmer = pr.Farmer,
                    CategoryId = pr.CategoryId,
                    Price = pr.Price,
                    DiscountPercentage = pr.DiscountPercentage ?? 0,
                    UnitType = pr.UnitType.ToString(),
                    Size = pr.Size,
                    Quantity = pr.Quantity,
                    Origin = pr.Origin ?? "",
                    ImageUrl = pr.ImageUrl ?? "",
                    ProductionDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
                    ExpirationDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmId(Guid farmId)
        {
            return await repository
                .AllAsync<Product>()
                .Where(pr => pr.Farm.Id == farmId)
                .Select(pr => new ProductInfoViewModel()
                {
                    Id = pr.Id.ToString(),
                    Name = pr.Name,
                    Description = pr.Description,
                    FarmId = pr.FarmId.ToString(),
                    Farm = pr.Farm,
                    FarmerId = pr.FarmerId.ToString(),
                    Farmer = pr.Farmer,
                    CategoryId = pr.CategoryId,
                    Price = pr.Price,
                    DiscountPercentage = pr.DiscountPercentage ?? 0,
                    UnitType = pr.UnitType.ToString(),
                    Size = pr.Size,
                    Quantity = pr.Quantity,
                    Origin = pr.Origin ?? "",
                    ImageUrl = pr.ImageUrl ?? "",
                    ProductionDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
                    ExpirationDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByCategoryId(int categoryId)
        {
            return await repository
                .AllAsync<Product>()
                .Where(pr => pr.CategoryId == categoryId)
                .Select(pr => new ProductInfoViewModel()
                {
                    Id = pr.Id.ToString(),
                    Name = pr.Name,
                    Description = pr.Description,
                    FarmId = pr.FarmId.ToString(),
                    Farm = pr.Farm,
                    FarmerId = pr.FarmerId.ToString(),
                    Farmer = pr.Farmer,
                    CategoryId = pr.CategoryId,
                    Price = pr.Price,
                    DiscountPercentage = pr.DiscountPercentage ?? 0,
                    UnitType = pr.UnitType.ToString(),
                    Size = pr.Size,
                    Quantity = pr.Quantity,
                    Origin = pr.Origin ?? "",
                    ImageUrl = pr.ImageUrl ?? "",
                    ProductionDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
                    ExpirationDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
                })
                .ToListAsync(); ;
        }
    }
}
