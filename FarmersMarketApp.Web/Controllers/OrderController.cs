using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;
		private readonly IFarmerService farmerService;
		private readonly IUserService userService;
		private readonly IProductService productService;
		public OrderController(IOrderService orderService,
			IFarmerService farmerService,
			IUserService userService,
			IProductService productService)
		{
			this.orderService = orderService;
			this.farmerService = farmerService;
			this.userService = userService;
			this.productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var currentUserId = User.GetId();

			//check if user is logged in and is a farmer - redirect him if so
			var isUserFarmer = await userService.IsUserFarmerAsync(currentUserId);
			if (isUserFarmer)
			{
				return RedirectToAction("MyProducts", "Farmer");
			}

			//get all open orders for user
			var order = await orderService.GetOrdersByUserIdAsync(currentUserId);

			return View(order);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> AddToCart(string productId, int productAmount)
		{
			var currentUserId = User.GetId();
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			var result = await orderService.AddToOrderAsync(currentUserId, productId, productAmount);

			//todo: figure out where to send user after he adds product
			return RedirectToAction("All", "Product");
		}

		[HttpGet]
		public async Task<IActionResult> RemoveFromCart(string orderId, string productId)
		{
			var currentUserId = User.GetId();
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			//check if order id is null
			if (string.IsNullOrEmpty(orderId))
			{
				return RedirectToAction(nameof(All));
			}

			var result = await orderService.RemoveFromOrderAsync(currentUserId, orderId, productId);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> RemoveAllFromCart(string orderId)
		{
			var currentUserId = User.GetId();
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			//check if order id is null
			if (string.IsNullOrEmpty(orderId))
			{
				return RedirectToAction(nameof(All));
			}

			var result = await orderService.RemoveAllProductsFromOrderAsync(currentUserId, orderId);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> Checkout(string orderId)
		{
			var currentUserId = User.GetId();
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			//check if order id is null
			if (string.IsNullOrEmpty(orderId))
			{
				return RedirectToAction(nameof(All));
			}

			var model = await orderService.GetOrderForCheckoutAsync(currentUserId, orderId);

			//if order not found, return to all orders
			if (model == null)
			{
				return View(nameof(All));
			}

			return View(model);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Checkout(OrderCheckoutViewModel model, string orderId)
		{
			//todo: add payment here maybe
			//todo: figure out how to add delivery details to model to avoid empty model on error

			var currentUserId = User.GetId();
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			var modelReload = await orderService.GetOrderForCheckoutAsync(currentUserId, orderId);
			if (modelReload != null)
			{
				model.Id = modelReload.Id;
				model.CustomerId = modelReload.CustomerId;
				model.OrderStatus = modelReload.OrderStatus;
				model.CreateDate = modelReload.CreateDate;
				model.Products = modelReload.Products;
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await orderService.ChangeOrderToPending(orderId);

			if (result)
			{
				TempData["success"] = "Payment successful!";
				return RedirectToAction(nameof(All));
			}

			return RedirectToAction("All", "Product");
		}
	}
}
