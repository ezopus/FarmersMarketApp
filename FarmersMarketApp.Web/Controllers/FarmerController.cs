using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.FarmerViewModels;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FarmersMarketApp.Common.NotificationConstants;

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
			var farmers = await farmerService.GetAllActiveFarmersAsync();

			return View(farmers);
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			//get current user id
			var currentUserId = User.GetId();

			//check if user is logged in
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			var isFarmer = await userService.IsUserFarmerAsync(currentUserId);

			//if user is already a farmer redirect to my farms
			if (isFarmer)
			{
				TempData[ErrorMessage] = AlreadyFarmer;
				return RedirectToAction(nameof(MyFarms), "Farmer");
			}

			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Become(FarmerBecomeViewModel model)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if user is farmer, if he already is, redirect him to his farms
			if (!string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("MyFarms", "Farmer");
			}

			//check model state
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//async create new farmer entity
			var result = await farmerService.BecomeFarmerAsync(currentUserId, model);

			if (string.IsNullOrEmpty(result))
			{
				return View(model);
			}

			TempData[SuccessMessage] = SuccessfullyApplyToBeFarmer;

			//redirect to my farms
			return RedirectToAction(nameof(MyFarms));
		}

		[HttpGet]
		//[MustBeFarmer]
		public async Task<IActionResult> MyFarms()
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get all farms for current farmer
			var farms = await farmService.GetAllFarmsByFarmerIdAsync(currentFarmerId);

			//check if farms list is empty, if yes redirect to add farm
			if (farms == null || !farms.Any())
			{
				return RedirectToAction("Add", "Farm");
			}

			//return model with all farms of current farmer
			return View(farms);
		}

		[HttpGet]
		//[MustBeFarmer]
		public async Task<IActionResult> MyProducts()
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get all products for current farmer
			var products = await productService.GetFarmerProductsByFarmerIdAsync(currentFarmerId);

			//check if products list is empty, if yes redirect to add product
			if (products == null || !products.Any())
			{
				return RedirectToAction("Add", "Product");
			}

			//return model with all farms to render view
			return View(products);
		}

		[HttpGet]
		public async Task<IActionResult> MyOrders(string farmerId)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			var model = await farmerService.GetFarmerOpenOrdersAsync(farmerId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> CompleteOrder(string orderId)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			var result = await farmerService.CompleteOrderByOrderIdAsync(currentFarmerId, orderId);
			if (result)
			{
				TempData[SuccessMessage] = "Successfully completed order!";
			}
			else
			{
				TempData[ErrorMessage] = "Operation failed. Please try again.";
			}

			return RedirectToAction(nameof(MyOrders), new { farmerId = currentFarmerId });
		}

		[HttpPost]
		public async Task<IActionResult> CancelOrder(string orderId)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			var result = await farmerService.CancelOrderByOrderIdAsync(currentFarmerId, orderId);

			if (result)
			{
				TempData[SuccessMessage] = "Successfully cancelled order!";
			}
			else
			{
				TempData[ErrorMessage] = "Operation failed. Please try again.";
			}

			return RedirectToAction(nameof(MyOrders), new { farmerId = currentFarmerId });
		}

		[HttpGet]
		public async Task<IActionResult> DeleteProduct(string productId)
		{
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if user is a farmer, if not redirect him to become one
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get product from db, if not found redirect to all products
			var product = await productService.GetProductByIdAsync(productId);

			if (product == null || product.IsDeleted)
			{
				return RedirectToAction(nameof(MyProducts));
			}

			//try to get farm and farmer of product and check if they are deleted
			var productFarmer = await farmerService.GetFarmerByIdAsync(product.FarmerId);

			if (productFarmer != null && productFarmer.Id.ToLower() != currentFarmerId.ToLower())
			{
				return RedirectToAction(nameof(MyProducts));
			}

			var result = await productService.SetProductIsDeletedByIdAsync(productId);
			if (result)
			{
				TempData[SuccessMessage] = string.Format(SuccessfullyDeleteProduct, product.Name);
			}
			else
			{
				TempData[ErrorMessage] = string.Format(FailedDeleteProduct, product.Name);
			}
			return RedirectToAction(nameof(MyProducts));
		}
		[HttpGet]
		public async Task<IActionResult> RestoreProduct(string productId)
		{
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if user is a farmer, if not redirect him to become one
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get product from db, if not found redirect to all products
			var product = await productService.GetProductByIdAsync(productId);

			if (product == null || !product.IsDeleted)
			{
				return RedirectToAction(nameof(MyProducts));
			}

			//try to get farm and farmer of product and check if they are deleted
			var productFarmer = await farmerService.GetFarmerByIdAsync(product.FarmerId);

			if (productFarmer != null && productFarmer.Id.ToLower() != currentFarmerId.ToLower())
			{
				return RedirectToAction(nameof(MyProducts));
			}

			var result = await productService.RestoreProductByIdAsync(productId);
			if (result)
			{
				TempData[SuccessMessage] = string.Format(SuccessfullyRestoreProduct, product.Name);
			}
			else
			{
				TempData[ErrorMessage] = string.Format(FailedRestoreProduct, product.Name);
			}
			return RedirectToAction(nameof(MyProducts));
		}
	}
}
