using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IProductService
	{
		Task<IEnumerable<ProductInfoAdminViewModel>> GetAllProductsAsync();

		Task<ProductsQueryModel> GetAllProductsWithQueryAsync(int? categoryId, string? farmId, string? farmerId, string? searchTerm, ProductSorting sorting, int currentPage, int productsPerPage);
		Task<IEnumerable<ProductInfoViewModel>> GetActiveProductsAsync();

		Task<ProductInfoViewModel?> GetProductByIdAsync(string id);

		Task<AddProductViewModel?> GetProductToEditByIdAsync(string id);

		Task<bool?> UpdateEditedProductAsync(AddProductViewModel viewModel);

		Task<Product?> GetProductByNameAsync(string name);

		Task<IEnumerable<ProductInfoViewModel>?> GetActiveProductsByFarmerIdAsync(string farmerId);

		Task<IEnumerable<ProductInfoViewModel>?> GetActiveProductsByFarmIdAsync(string farmId);

		Task<IEnumerable<ProductInfoViewModel>?> GetProductsByCategoryIdAsync(int categoryId);

		Task<string?> CreateProductAsync(AddProductViewModel model);

		Task<Product?> GetProductForOrderByProductIdAsync(string productId);

		Task<IEnumerable<Product>> GetProductsForDeletionByFarmIdAsync(string farmId);
		Task<IEnumerable<Product>> GetProductsForDeletionByFarmerIdAsync(string farmerId);
		Task<bool> SetProductIsDeletedByIdAsync(string productId);
		Task<bool> RestoreProductByIdAsync(string productId);

		Task<IEnumerable<ProductFarmerOrderViewModel>> GetFarmerProductOrdersByOrderIdAsync(string orderId);

	}
}
