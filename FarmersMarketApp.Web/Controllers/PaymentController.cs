using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.PaymentVIewModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	public class PaymentController : BaseController
	{
		private readonly IPaymentService paymentService;
		private readonly IOrderService orderService;
		public PaymentController(
			IPaymentService paymentService,
			IOrderService orderService)
		{
			this.paymentService = paymentService;
			this.orderService = orderService;
		}

		[HttpGet]
		public async Task<IActionResult> Checkout(string customerId, string orderId)
		{
			var currentUserId = User.GetId();
			if (customerId != currentUserId)
			{
				return RedirectToAction("Checkout", "Order", new { orderId });
			}

			var currentOrder = await orderService.GetOrderForCheckoutAsync(customerId, orderId);
			if (currentOrder == null)
			{
				return RedirectToAction("Checkout", "Order", new { orderId });
			}

			var model = new PaymentCheckoutViewModel()
			{
				CustomerId = customerId,
				OrderId = orderId,
				TotalPrice = currentOrder.TotalPrice,
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(PaymentCheckoutViewModel model, string customerId, string orderId, string paymentType)
		{
			//check if current user Id matches user of customer in order
			var currentUserId = User.GetId();
			if (customerId != currentUserId)
			{
				return RedirectToAction("Checkout", "Order", new { orderId });
			}

			//get order
			var currentOrder = await orderService.GetOrderByIdAsync(orderId);
			if (currentOrder == null)
			{
				return RedirectToAction("All", "Order");
			}

			var orderAmount = orderService.GetOrderForCheckoutAsync(currentUserId, orderId).Result!.TotalPrice;

			var paymentTypeParsed = Enum.Parse<PaymentType>(paymentType);

			//check if card payment option is picked and get details
			if (paymentTypeParsed == PaymentType.CardPayment
				&& !ModelState.IsValid)
			{
				return View(model);
			}

			//try and create a new payment
			var paymentResult = await paymentService.CreateNewPayment(customerId, orderId, paymentTypeParsed, orderAmount, currentOrder);

			if (string.IsNullOrEmpty(paymentResult))
			{
				return RedirectToAction("Checkout", "Order");
			}

			await orderService.ChangeOrderToPendingAsync(orderId);

			return RedirectToAction("All", "Order");
		}
	}
}
