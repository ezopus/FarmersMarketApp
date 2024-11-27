using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IProductService
	{
		Task<ProductsQueryModel> GetAllProductsAsync(int? categoryId, string? farmId, string? farmerId, string? searchTerm, ProductSorting sorting, int currentPage, int productsPerPage);

		Task<ProductsQueryModel> GetAllActiveProductsWithQueryAsync(int? categoryId, string? farmId, string? farmerId, string? searchTerm, ProductSorting sorting, int currentPage, int productsPerPage);

		Task<ProductInfoViewModel?> GetProductByIdAsync(string id);

		Task<AddProductViewModel?> GetProductToEditByIdAsync(string id);

		Task<bool?> UpdateEditedProductAsync(AddProductViewModel viewModel, string? newFilePath);


		Task<IEnumerable<ProductInfoViewModel>?> GetFarmerProductsByFarmerIdAsync(string farmerId);


		Task<string?> CreateProductAsync(AddProductViewModel model);

		Task<Product?> GetProductForOrderByProductIdAsync(string productId);

		Task<IEnumerable<Product>> GetProductsForDeletionByFarmIdAsync(string farmId);
		Task<IEnumerable<Product>> GetProductsForDeletionByFarmerIdAsync(string farmerId);
		Task<bool> SetProductIsDeletedByIdAsync(string productId);
		Task<bool> RestoreProductByIdAsync(string productId);

		Task<IEnumerable<ProductFarmerOrderViewModel>> GetFarmerProductOrdersByOrderIdAsync(string farmerId, string orderId);

	}
}
