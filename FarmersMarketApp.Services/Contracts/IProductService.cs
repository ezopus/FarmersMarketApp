﻿using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product?> GetProductById(Guid id);

        Task<Product?> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductsByFarmerId(Guid farmerId);

        Task<IEnumerable<Product>> GetProductsByFarmId(Guid farmId);

        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}