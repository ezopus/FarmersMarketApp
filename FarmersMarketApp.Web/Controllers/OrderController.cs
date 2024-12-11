using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.OrderViewModels;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FarmersMarketApp.Common.NotificationConstants;

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
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			//check if user is logged in and is a farmer - redirect him if so
			var isUserFarmer = await userService.IsUserFarmerAsync(currentUserId);
			if (isUserFarmer)
			{
				return RedirectToAction("MyProducts", "Farmer");
			}

			//get all open orders for user
			var order = await orderService.GetOrdersByUserIdAsync(currentUserId);

			var model = new ManageUserOrdersViewModel()
			{
				Orders = order
			};

			return View(model);
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

			if (productAmount < 0)
			{
				TempData[ErrorMessage] = ErrorProductAmountNegativeNumber;
				return RedirectToAction("All", "Product");
			}
			if (productAmount > 30)
			{
				TempData[ErrorMessage] = ErrorProductAmountTooMuch;
				return RedirectToAction("All", "Product");
			}

			var result = await orderService.AddToOrderAsync(currentUserId, productId, productAmount);

			if (result == true)
			{
				TempData[SuccessMessage] = SuccessfullyAddProductToCart;
			}

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
		public async Task<IActionResult> Checkout(OrderCheckoutViewModel model, string orderId)
		{
			var currentUserId = User.GetId();
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			//fetch model to reload display data for razor view in case validations fail
			var modelReload = await orderService.GetOrderForCheckoutAsync(currentUserId, orderId);
			if (modelReload != null)
			{
				model.Id = modelReload.Id;
				model.CustomerId = modelReload.CustomerId;
				model.Status = modelReload.Status;
				model.CreateDate = modelReload.CreateDate;
				model.Products = modelReload.Products;
			}

			//check if delivery details are added properly
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var addDeliveryResult = await orderService.AddDeliveryDetailsToOrderByIdAsync(orderId, model);

			if (!addDeliveryResult)
			{
				return RedirectToAction("Checkout", "Order", new { orderId });
			}

			return RedirectToAction("Checkout", "Payment", new { customerId = currentUserId, orderId });
		}
	}
}
