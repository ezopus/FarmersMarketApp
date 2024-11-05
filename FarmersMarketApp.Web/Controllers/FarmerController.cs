using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	public class FarmerController : BaseController
	{
		private readonly IRepository repository;
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		private readonly IUserService userService;

		public FarmerController(
			IRepository repository,
			IUserService userService,
			IFarmerService farmerService,
			IFarmService farmService)
		{
			this.repository = repository;
			this.farmerService = farmerService;
			this.userService = userService;
		}
		public async Task<IActionResult> Index()
		{
			var currentUserId = User.GetId();


			return View();
		}

		[HttpGet]
		public IActionResult Become()
		{
			if (User.Identity?.IsAuthenticated == null)
			{
				return RedirectToPage("/Account/Login");
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(FarmerBecomeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var currentUserId = User.GetId();
			var currentUser = await userService.GetCurrentUser(Guid.Parse(currentUserId));

			if (currentUser == null || currentUser.IsFarmer)
			{
				return RedirectToAction(nameof(Index), "Home");
			}

			await farmerService.BecomeFarmerAsync(currentUser, model);

			return RedirectToAction(nameof(Index));
		}

	}
}
