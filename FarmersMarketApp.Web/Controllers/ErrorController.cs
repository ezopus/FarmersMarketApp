using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	public class ErrorController : Controller
	{
		[Route("Error/{statusCode}")]
		public IActionResult HttpStatusCodeHandler(int statusCode)
		{
			var viewName = statusCode switch
			{
				401 => "Unauthorized",
				403 => "Unauthorized",
				404 => "NotFound",
				405 => "NotApproved",
				500 => "ServerError",
				_ => "Error"
			};

			return View(viewName);
		}
	}
}
