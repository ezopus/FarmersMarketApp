using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.FarmValidation;

namespace FarmersMarketApp.Web.Controllers
{
	public class FarmController : BaseController
	{
		private readonly IRepository repository;
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		public FarmController(
			IRepository repository,
			IFarmService farmService,
			IFarmerService farmerService)
		{
			this.repository = repository;
			this.farmService = farmService;
			this.farmerService = farmerService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index(Guid? farmerId)
		{
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(Guid.Parse(currentUserId));

			if (currentFarmerId != null)
			{
				ViewData["farmerId"] = currentFarmerId.ToString();
			}

			//check if route has farmer id parameters and if yes show only farms by one farmer
			//TODO: add switch case for filtration by category 
			var farms = farmerId.HasValue
				? await farmService.GetFarmsByFarmerIdAsync(farmerId.Value)
				: await farmService.GetFarmsAsync();

			return View(farms);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddFarmViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (model.OpenHours != null || model.CloseHours != null)
			{
				var isOpenHoursValid = TimeOnly.TryParseExact(model.OpenHours, TimeRequiredFormat,
					CultureInfo.CurrentCulture, DateTimeStyles.None, out var openHoursParsed);
				var isCloseHoursValid = TimeOnly.TryParseExact(model.CloseHours, TimeRequiredFormat,
					CultureInfo.CurrentCulture, DateTimeStyles.None, out var closedHoursParsed);

				if (model.OpenHours != null && !isOpenHoursValid)
				{
					ModelState.AddModelError(nameof(model.OpenHours), ErrorFarmHours);
					return View(model);
				}
				if (model.CloseHours != null && !isCloseHoursValid)
				{
					ModelState.AddModelError(nameof(model.CloseHours), ErrorFarmHours);
					return View(model);
				}

			}

			var currentUserId = Guid.Parse(User.GetId());
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);
			var newFarmId = string.Empty;

			if (currentFarmerId != null)
			{
				var newFarm = await farmService.AddNewFarmAsync(model, currentFarmerId.Value);
				newFarmId = newFarm.Id.ToString();
			}

			return RedirectToAction(nameof(Details), new { farmId = newFarmId });
		}


		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid farmId)
		{
			var model = await farmService.GetFarmByIdAsync(farmId);

			return View(model);
		}
	}
}
