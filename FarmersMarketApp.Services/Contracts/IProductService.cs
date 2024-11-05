using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductInfoViewModel>> GetProductsAsync();

        Task<ProductInfoViewModel?> GetProductById(Guid id);

        Task<Product?> GetProductByName(string name);

        Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmerId(Guid farmerId);

        Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmId(Guid farmId);

        Task<IEnumerable<ProductInfoViewModel>> GetProductsByCategoryId(int categoryId);
    }
}
