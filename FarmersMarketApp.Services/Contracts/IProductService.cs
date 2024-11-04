using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductInfoViewModel>> GetProductsAsync();

        Task<Product?> GetProductById(Guid id);

        Task<Product?> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductsByFarmerId(Guid farmerId);

        Task<IEnumerable<Product>> GetProductsByFarmId(Guid farmId);

        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}
