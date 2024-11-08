using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	public class CartController : Controller
	{
		public async Task<IActionResult> MyCart()
		{
			return View();
		}

		public async Task<IActionResult> AddToCart()
		{
			return Ok();
		}
	}
}
