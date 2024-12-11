using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		public ProductController(
			IProductService productService,
			ICategoryService categoryService,
			IFarmService farmService,
			IFarmerService farmerService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
			this.farmService = farmService;
			this.farmerService = farmerService;
		}

		[HttpGet]
		public async Task<IActionResult> Manage([FromQuery] ProductsQueryModel model)
		{
			var products = await productService.GetAllProductsAsync(
				model.Category,
				model.FarmId,
				model.FarmerId,
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				model.ProductsPerPage);

			if (model.DeletedOnly)
			{
				model.Products = products.Products.Where(pr => pr.IsDeleted).ToList();
				model.TotalProducts = products.Products.Count(pr => pr.IsDeleted);
			}
			else
			{
				model.Products = products.Products;
				model.TotalProducts = products.TotalProducts;
			}

			var paginatedProducts = model.Products
				.Skip((model.CurrentPage - 1) * model.ProductsPerPage)
				.Take(model.ProductsPerPage)
				.OrderByDescending(pr => pr.IsDeleted)
				.ToList();

			model.Products = paginatedProducts.OrderByDescending(pr => pr.IsDeleted);
			model.Categories = await categoryService.GetCategoriesAsync();
			model.Farmers = (await farmerService.GetAllApprovedAndActiveFarmerNamesAndIdsAsync()).OrderBy(f => f.Name);
			model.Farms = (await farmService.GetAllFarmNamesAndIdsAsync()).OrderBy(f => f.Name);

			return View(model);
		}

		public async Task<IActionResult> Restore(string productId)
		{
			var result = await productService.RestoreProductByIdAsync(productId);

			return RedirectToAction(nameof(Manage), new { });
		}
		public async Task<IActionResult> Delete(string productId)
		{
			var result = await productService.SetProductIsDeletedByIdAsync(productId);

			return RedirectToAction(nameof(Manage), new { });
		}

	}
}
