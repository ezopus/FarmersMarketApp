using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

namespace FarmersMarketApp.Web.Controllers
{
	public class FarmController : BaseController
	{
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		public FarmController(
			IFarmService farmService,
			IFarmerService farmerService)
		{
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
		public async Task<IActionResult> Edit(Guid farmId)
		{
			//get current user and check if he's a farmer
			var currentUserId = Guid.Parse(User.GetId());
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			if (currentFarmerId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			//check if current edited farm is property of farmer
			var farmerFarms = await farmService.GetFarmIdsByFarmerId(currentFarmerId.Value);
			if (farmerFarms.All(f => f.ToLower() != farmId.ToString().ToLower()))
			{
				return RedirectToAction(nameof(Index));
			}

			//get tracked entity of farm to edit via services
			var farmToEdit = await farmService.GetFarmToEditByIdAsync(farmId);

			//if farm not found, redirect to all farms
			if (farmToEdit == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(farmToEdit);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AddFarmViewModel model)
		{
			//if model is invalid, return
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//check input hours for validation to add error to proper field
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

			//try to edit farm
			var result = await farmService.EditFarmAsync(model);

			//if service fails, returns view
			if (!result)
			{
				return View(model);
			}

			return RedirectToAction(nameof(Details), new { farmId = model.Id });
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid farmId)
		{
			var model = await farmService.GetFarmByIdReadOnlyAsync(farmId);

			return View(model);
		}
	}
}
