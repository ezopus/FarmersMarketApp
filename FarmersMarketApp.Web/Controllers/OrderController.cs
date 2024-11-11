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

			var model = await orderService.GetOrderForCheckoutAsync(currentUserId, orderId);

			//if order not found, return to all orders
			if (model == null)
			{
				return View(nameof(All));
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Checkout(OrderCheckoutViewModel model)
		{
			//todo: add payment here maybe

			if (!ModelState.IsValid)
			{

				return View(model);
			}

			return RedirectToAction(nameof(All));
		}
	}
}
