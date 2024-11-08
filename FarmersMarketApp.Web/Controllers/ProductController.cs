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
		public async Task<IActionResult> All(string? farmerId, string? farmerFullName, string? farmId, string? farmName)
		{
			if (!string.IsNullOrEmpty(farmerId))
			{
				ViewData["farmerId"] = farmerId;
				ViewData["farmerFullName"] = farmerFullName;
				var model = await productService.GetProductsByFarmerIdAsync(Guid.Parse(farmerId));
				return View(model);
			}

			if (!string.IsNullOrEmpty(farmId))
			{
				ViewData["farmName"] = farmName;
				var model = await productService.GetProductsByFarmIdAsync(farmId);
				return View(model);
			}

			var allModels = await productService.GetProductsAsync();

			return View(allModels);
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
			var currentUserId = Guid.Parse(User.GetId());
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			if (!ModelState.IsValid)
			{
				model.Categories = await categoryService.GetCategoriesAsync();
				model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
				model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
				return View(model);
			}


			//check if current user is farmer
			if (currentFarmerId == null || model.FarmerId != currentFarmerId)
			{
				return RedirectToAction(nameof(All));
			}

			//check if current farmer is working on farm to add product to
			var farmerFarms = await farmService.GetFarmIdsByFarmerId(currentFarmerId.Value);
			if (!farmerFarms.Any())
			{
				return RedirectToAction(nameof(All));
			}

			var result = await productService.CreateProductAsync(model);

			if (result == null)
			{
				return View(model);
			}

			return RedirectToAction("Details", "Product", new { id = result.Value });
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

			model.Farm = await farmService.GetFarmByIdReadOnlyAsync(Guid.Parse(model.FarmId));
			model.Farmer = await farmerService.GetFarmerIdByAsync(model.FarmerId);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid productId)
		{
			var model = await productService.GetProductToEditByIdAsync(productId);

			if (model == null)
			{
				return RedirectToAction(nameof(All));
			}

			var currentUserId = Guid.Parse(User.GetId());
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			if (currentFarmerId == null)
			{
				return RedirectToAction(nameof(All));
			}
			var currentFarmerFarms = await farmService.GetFarmIdsByFarmerId(currentFarmerId.Value);

			if (!currentFarmerFarms.Any(f => f.Equals(model.FarmId.ToString(), StringComparison.CurrentCultureIgnoreCase)))
			{
				return RedirectToAction(nameof(All));
			}

			model.Categories = await categoryService.GetCategoriesAsync();
			model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
			model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
			model.Farms = await farmService.GetFarmNameAndIdForNewProductAsync(currentFarmerId.Value);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AddProductViewModel model)
		{
			var currentUserId = Guid.Parse(User.GetId());
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			if (!ModelState.IsValid)
			{
				model.Categories = await categoryService.GetCategoriesAsync();
				model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
				model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
				return View(model);
			}


			//check if current user is farmer
			if (currentFarmerId == null || model.FarmerId != currentFarmerId)
			{
				return RedirectToAction(nameof(All));
			}

			//check if current farmer is working on farm to add product to
			var farmerFarms = await farmService.GetFarmIdsByFarmerId(currentFarmerId.Value);
			if (!farmerFarms.Any())
			{
				return RedirectToAction(nameof(All));
			}

			var result = await productService.UpdateEditedProductAsync(model);

			if (result == null)
			{
				return View(model);
			}

			return RedirectToAction("Details", "Product", new { id = model.Id });
		}

		[HttpGet]
		public async Task<IActionResult> Delete()
		{
			return View();
		}
	}
}
