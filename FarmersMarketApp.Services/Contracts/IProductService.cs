using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IProductService
	{
		Task<IEnumerable<ProductInfoViewModel>> GetProductsAsync();

		Task<ProductInfoViewModel?> GetProductByIdAsync(Guid id);

		Task<Product?> GetProductByNameAsync(string name);

		Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmerIdAsync(Guid farmerId);

		Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmIdAsync(string farmId);

		Task<IEnumerable<ProductInfoViewModel>> GetProductsByCategoryIdAsync(int categoryId);

		Task<Guid?> CreateProductAsync(AddProductViewModel model);


	}
}
