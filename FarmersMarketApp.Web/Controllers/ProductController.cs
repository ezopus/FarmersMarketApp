using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		//private readonly IOrderService orderService;

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

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All(Guid? farmerId, string? farmerFullName)
		{
			if (farmerId.HasValue && farmerFullName != null)
			{
				ViewData["farmerId"] = farmerId;
				ViewData["farmerFullName"] = farmerFullName;
			}

			var model = farmerId.HasValue
				? await productService.GetProductsByFarmerIdAsync(farmerId.Value)
				: await productService.GetProductsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			//get current userId
			var currentUserId = Guid.Parse(User.GetId());
			var farmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if user is a farmer, if not, redirect him to become a farmer
			if (farmerId == null)
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get all farms where farmer is registered
			var farmerFarms = await farmService.GetFarmNameAndIdForNewProductAsync(farmerId.Value);

			//check if farmer has farms, if not - redirect him to add a farm
			if (!farmerFarms.Any())
			{
				return RedirectToAction(nameof(Add), "Farm");
			}

			//create a new model and populate drop down options
			var model = new AddProductViewModel();
			model.Categories = await categoryService.GetCategoriesAsync();
			model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
			model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
			model.Farms = farmerFarms;
			model.FarmerId = farmerId.Value;

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Add(AddProductViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

		//TODO: Implement categories

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var model = await productService.GetProductByIdAsync(id);
			if (model == null)
			{
				return RedirectToAction("All");
			}
			return View(model);
		}

		//TODO: Implement product edit
		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Guid productId)
		{
			return RedirectToAction(nameof(Details), new { productId });
		}
	}
}
