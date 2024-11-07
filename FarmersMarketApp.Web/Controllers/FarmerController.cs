using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;

namespace FarmersMarketApp.Web.Controllers
{
	public class FarmerController : BaseController
	{
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		private readonly IUserService userService;
		private readonly IProductService productService;

		public FarmerController(
			IUserService userService,
			IFarmerService farmerService,
			IFarmService farmService,
			IProductService productService)
		{
			this.farmerService = farmerService;
			this.userService = userService;
			this.farmService = farmService;
			this.productService = productService;
		}

		//get all farmers in the market
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var farmers = await farmerService.GetAllFarmersAsync();
			return View(farmers);
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			//get current user id
			var currentUserId = Guid.Parse(User.GetId());
			var isFarmer = await userService.IsUserFarmerAsync(currentUserId);

			//if user is already a farmer redirect to my farms
			if (isFarmer)
			{
				return RedirectToAction(nameof(MyFarms), "Farmer");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(FarmerBecomeViewModel model)
		{
			//check model state
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//check if accept deliveries is pressed and set error if not
			//workaround to not have any button selected when initial loading of page
			if (model.AcceptsDeliveries == null)
			{
				ModelState.AddModelError(nameof(model.AcceptsDeliveries), ErrorAcceptDeliveriesNotSelected);
				return View(model);
			}

			//get current user
			var currentUserId = Guid.Parse(User.GetId());
			var isFarmer = await userService.IsUserFarmerAsync(currentUserId);

			//check if user exists or if yes if user is already a farmer and redirect if so
			if (isFarmer)
			{
				return RedirectToAction(nameof(Index), "Home");
			}

			//async create new farmer entity
			await farmerService.BecomeFarmerAsync(currentUserId, model);

			//redirect to my farms
			return RedirectToAction(nameof(MyFarms));
		}

		[HttpGet]
		//[MustBeFarmer]
		public async Task<IActionResult> MyFarms()
		{
			//get current user
			var currentUser = await userService.GetCurrentUserByIdAsync(Guid.Parse(User.GetId()));

			//check if user exists, redirect to index if not existing
			if (currentUser == null)
			{
				return RedirectToAction("Index", "Home");
			}

			//check if user is a farmer, if not send him to become one
			if (!currentUser.IsFarmer)
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get corresponding farmer Id based on current UserId
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUser.Id);

			//get all farms for current farmer
			var farms = await farmService.GetFarmsByFarmerIdAsync(currentFarmerId!.Value);

			//check if farms list is empty, if yes redirect to add farm
			if (!farms.Any())
			{
				return RedirectToAction("Add", "Farm");
			}

			//return model with all farms to render view
			return View(farms);
		}

		[HttpGet]
		//[MustBeFarmer]
		public async Task<IActionResult> MyProducts()
		{
			//get current user
			var currentUser = await userService.GetCurrentUserByIdAsync(Guid.Parse(User.GetId()));

			//check if user exists, redirect to index if not existing
			if (currentUser == null)
			{
				return RedirectToAction("Index", "Home");
			}

			//check if user is a farmer, if not send him to become one
			if (!currentUser.IsFarmer)
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get corresponding farmer Id based on current UserId
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUser.Id);

			//get all products for current farmer
			var products = await productService.GetProductsByFarmerIdAsync(currentFarmerId!.Value);

			//check if products list is empty, if yes redirect to add product
			if (!products.Any())
			{
				return RedirectToAction("Add", "Product");
			}

			//return model with all farms to render view
			return View(products);
		}

	}
}
