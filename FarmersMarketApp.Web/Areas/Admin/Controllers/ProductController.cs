using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Manage()
		{
			//gets all products which are not deleted
			var allModels = await productService.GetAllProductsAsync();

			return View(allModels);
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
