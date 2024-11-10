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
		public async Task<IActionResult> Index(string? farmerId)
		{
			var currentUserId = User.GetId();
			var currentFarmerId = "";

			if (!string.IsNullOrEmpty(currentUserId))
			{
				currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);
			}

			if (!string.IsNullOrEmpty(currentFarmerId))
			{
				ViewData["farmerId"] = currentFarmerId;
			}

			//check if route has farmer id parameters and if yes show only farms by one farmer
			//TODO: add switch case for filtration by category 
			var farms = !string.IsNullOrEmpty(farmerId)
				? await farmService.GetAllFarmsByFarmerIdAsync(farmerId)
				: await farmService.GetFarmsAsync();

			return View(farms);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//ensure current user is a farmer, otherwise redirect him to become one
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			return View();
		}

		[HttpPost]
		//todo: add anti-forgery token to post action
		public async Task<IActionResult> Add(AddFarmViewModel model)
		{
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//ensure current user is a farmer, otherwise redirect him to become one
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//check model state of add farm model
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//try to parse dates for open and close hours of farm and add errors to proper fields
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

			//create new farm for current farmer
			var newFarm = await farmService.AddNewFarmAsync(model, currentFarmerId);
			var newFarmId = newFarm;

			//return farm details view to see newly added farm
			return RedirectToAction(nameof(Details), new { farmId = newFarmId });
		}


		[HttpGet]
		public async Task<IActionResult> Edit(string farmId)
		{
			//get current user and check if he's a farmer
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if user is a farmer, if not redirect him to become one
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get a list of all farm Id's of this farmer 
			var farmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId);

			//check if farmer has any farms and if currently edited farm has employed current farmer
			if (farmerFarms != null && farmerFarms.All(id => id.ToLower() != farmId.ToLower()))
			{
				return RedirectToAction(nameof(Index));
			}

			//get tracked entity of farm to edit
			var farmToEdit = await farmService.GetFarmToEditByIdAsync(farmId);

			//if farm not found, redirect to all farms
			if (farmToEdit == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(farmToEdit);
		}

		[HttpPost]
		//todo: add anti-forgery token here
		public async Task<IActionResult> Edit(AddFarmViewModel model)
		{
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//ensure current user is a farmer, otherwise redirect him to become one
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get a list of all farm Id's of this farmer 
			var farmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId);

			//check if farmer has any farms and if currently edited farm has employed current farmer
			if (farmerFarms != null && farmerFarms.All(id => id.ToLower() != model.Id.ToLower()))
			{
				return RedirectToAction(nameof(Index));
			}

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

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Details(string farmId)
		{
			var model = await farmService.GetFarmByIdReadOnlyAsync(farmId);

			return View(model);
		}
	}
}
