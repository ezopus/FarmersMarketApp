using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FarmersMarketApp.Web.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IFarmService farmService;
		public HomeController(ILogger<HomeController> logger, IFarmService farmService)
		{
			_logger = logger;
			this.farmService = farmService;
		}

		public async Task<IActionResult> Index()
		{
			var model = await farmService.GetThreeRandomFarmsForIndexCarousel();
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}