using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.FarmerViewModels;
using FarmersMarketApp.ViewModels.OrderViewModels;
using FarmersMarketApp.Web.Attributes;
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
		private readonly IOrderService orderService;

		public FarmerController(
			IUserService userService,
			IFarmerService farmerService,
			IFarmService farmService,
			IProductService productService,
			IOrderService orderService)
		{
			this.farmerService = farmerService;
			this.userService = userService;
			this.farmService = farmService;
			this.productService = productService;
			this.orderService = orderService;
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
			if (User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}

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

			//check if user has open orders
			var userOrders = await orderService.GetOrdersByUserIdAsync(currentUserId);
			if (userOrders != null && userOrders.Any(o => o.Status == Status.Open))
			{
				TempData[ErrorMessage] = FailedToApplyToBeFarmerUserHasOpenOrders;
				return RedirectToAction("All", "Order");
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
				TempData[ErrorMessage] = FailedToApplyToBeFarmer;
				return View(model);
			}

			TempData[SuccessMessage] = SuccessfullyApplyToBeFarmer;

			//redirect to my farms
			return RedirectToAction(nameof(MyFarms));
		}

		[HttpGet]
		[MustBeApprovedFarmer]
		public async Task<IActionResult> MyFarms()
		{
			TempData[SuccessMessage] = "";
			TempData[ErrorMessage] = "";

			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists
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
		[MustBeApprovedFarmer]
		public async Task<IActionResult> MyProducts()
		{
			TempData[SuccessMessage] = "";
			TempData[ErrorMessage] = "";

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
		[MustBeApprovedFarmer]
		public async Task<IActionResult> MyOrders(string farmerId)
		{
			TempData[SuccessMessage] = "";
			TempData[ErrorMessage] = "";

			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			var orders = await farmerService.GetFarmerOpenOrdersAsync(farmerId);

			var model = new ManageFarmerOrdersViewModel()
			{
				Orders = orders,
			};

			return View(model);
		}

		[HttpPost]
		[MustBeApprovedFarmer]
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

			var farmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId);

			var result = await orderService.CompleteProductOrderByOrderIdAsync(orderId, farmerFarms);

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
		[MustBeApprovedFarmer]
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

			var farmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId);

			var result = await orderService.CancelProductOrderByOrderIdAsync(orderId, farmerFarms);

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
		[MustBeApprovedFarmer]
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
		[MustBeApprovedFarmer]
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
