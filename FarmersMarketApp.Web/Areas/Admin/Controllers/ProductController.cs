using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
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
		public ProductController(
			IProductService productService,
			ICategoryService categoryService,
			IFarmService farmService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
			this.farmService = farmService;
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

			model.Products = products.Products;
			model.Categories = await categoryService.GetCategoriesAsync();
			model.Farms = await farmService.GetAllFarmNamesAndIdsAsync();
			model.TotalProducts = products.TotalProducts;

			return View(model);
		}

		public async Task<IActionResult> Restore(string productId)
		{
			var result = await productService.RestoreProductByIdAsync(productId);

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> Delete(string productId)
		{
			var result = await productService.SetProductIsDeletedByIdAsync(productId);

			return RedirectToAction(nameof(Manage));
		}

	}
}
