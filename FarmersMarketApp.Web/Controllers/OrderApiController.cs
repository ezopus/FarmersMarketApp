using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	[Route("api/order")]
	[ApiController]
	[Authorize]
	public class OrderApiController : ControllerBase
	{
		private readonly IOrderService orderService;
		public OrderApiController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpGet]
		[Route("details/{orderId}")]
		public async Task<IActionResult> GetOrderDetails(string orderId)
		{
			var products = await orderService.GetProductsForOrderByOrderIdAsync(orderId);

			if (products == null)
			{
				return NotFound();
			}

			return Ok(products);
		}


	}
}
