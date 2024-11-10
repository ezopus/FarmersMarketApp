using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IProductService
	{
		Task<IEnumerable<ProductInfoViewModel>> GetProductsAsync();

		Task<ProductInfoViewModel?> GetProductByIdAsync(string id);

		Task<AddProductViewModel?> GetProductToEditByIdAsync(string id);

		Task<bool?> UpdateEditedProductAsync(AddProductViewModel viewModel);

		Task<Product?> GetProductByNameAsync(string name);

		Task<IEnumerable<ProductInfoViewModel>?> GetProductsByFarmerIdAsync(string farmerId);

		Task<IEnumerable<ProductInfoViewModel>?> GetProductsByFarmIdAsync(string farmId);

		Task<IEnumerable<ProductInfoViewModel>?> GetProductsByCategoryIdAsync(int categoryId);

		Task<string?> CreateProductAsync(AddProductViewModel model);


	}
}
