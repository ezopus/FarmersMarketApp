using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.FarmViewModels;
using FarmersMarketApp.Web.Attributes;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;
using static FarmersMarketApp.Common.NotificationConstants;

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
			var farms = !string.IsNullOrEmpty(farmerId)
				? await farmService.GetAllFarmsByFarmerIdAsync(farmerId)
				: await farmService.GetActiveFarmsAsync();

			return View(farms);
		}

		[MustBeApprovedFarmer]
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

		[MustBeApprovedFarmer]
		[HttpPost]
		[AutoValidateAntiforgeryToken]
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

			//prepare file upload folder
			var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
			if (!Directory.Exists(uploadsPath))
			{
				Directory.CreateDirectory(uploadsPath);
			}

			//handle file upload
			if (model.ImageFile != null && model.ImageFile.Length > 0)
			{
				var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
				var fileExtension = Path.GetExtension(model.ImageFile.FileName).ToLower();

				if (!allowedExtensions.Contains(fileExtension))
				{
					ModelState.AddModelError(nameof(model.ImageFile), "Only JPG, JPEG, and PNG files are allowed.");
					return View(model);
				}

				if (model.ImageFile.Length > 2 * 1024 * 1024) // 2 MB limit
				{
					ModelState.AddModelError(nameof(model.ImageFile), "The file size cannot exceed 2 MB.");
					return View(model);
				}

				var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await model.ImageFile.CopyToAsync(stream);
				}

				//add the relative path to the model.ImageUrl for database storage
				model.ImageUrl = $"/uploads/{uniqueFileName}";
			}

			//create new farm for current farmer
			var newFarm = await farmService.AddNewFarmAsync(model, currentFarmerId);
			var newFarmId = newFarm;

			if (string.IsNullOrEmpty(newFarm))
			{
				TempData[ErrorMessage] = string.Format(FailedAddFarm, model.Name);
				return View(model);
			}


			//return farm details view to see newly added farm
			TempData[SuccessMessage] = string.Format(SuccessfullyAddFarm, model.Name);
			return RedirectToAction(nameof(Details), new { farmId = newFarmId });
		}


		[MustBeApprovedFarmer]
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
		[AutoValidateAntiforgeryToken]
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

			var newFilePath = string.Empty;
			//handle file upload
			if (model.ImageFile != null && model.ImageFile.Length > 0)
			{
				var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
				var fileExtension = Path.GetExtension(model.ImageFile.FileName).ToLower();

				if (!allowedExtensions.Contains(fileExtension))
				{
					ModelState.AddModelError(nameof(model.ImageFile), "Only JPG, JPEG, and PNG files are allowed.");
					return View(model);
				}

				if (model.ImageFile.Length > 2 * 1024 * 1024) // 2 MB limit
				{
					ModelState.AddModelError(nameof(model.ImageFile), "The file size cannot exceed 2 MB.");
					return View(model);
				}

				var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await model.ImageFile.CopyToAsync(stream);
				}
				//add the relative path to the model.ImageUrl for database storage
				newFilePath = $"/uploads/{uniqueFileName}";
			}

			//try to edit farm
			var result = await farmService.EditFarmAsync(model, newFilePath);

			//if service fails, returns view
			if (!result)
			{
				TempData[ErrorMessage] = string.Format(FailedEditFarm, model.Name);
				return View(model);
			}


			TempData[SuccessMessage] = string.Format(SuccessfullyEditFarm, model.Name);

			return RedirectToAction(nameof(Details), new { farmId = model.Id });
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Details(string farmId)
		{
			var model = await farmService.GetFarmByIdReadOnlyAsync(farmId);

			//check if farm has been deleted, if yes - redirect to all farms
			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[MustBeApprovedFarmer]
		[HttpGet]
		public async Task<IActionResult> Delete(string farmId)
		{
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(User.GetId());

			if (currentFarmerId == null)
			{
				return RedirectToAction("MyFarms", "Farmer");
			}

			var result = await farmService.SetFarmIsDeletedByFarmIdAsync(farmId);

			if (result == false)
			{
				TempData[ErrorMessage] = FailedDeleteFarm;
				return RedirectToAction("MyFarms", "Farmer");
			}

			TempData[SuccessMessage] = SuccessfullyDeleteFarm;
			return RedirectToAction("MyFarms", "Farmer");
		}

		[MustBeApprovedFarmer]
		[HttpGet]
		public async Task<IActionResult> Restore(string farmId)
		{
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(User.GetId());

			if (currentFarmerId == null)
			{
				return RedirectToAction("MyFarms", "Farmer");
			}

			var result = await farmService.RestoreFarmByFarmIdAsync(farmId);

			if (result == false)
			{
				TempData[ErrorMessage] = FailedRestoreFarm;
				return RedirectToAction("MyFarms", "Farmer");
			}

			TempData[SuccessMessage] = SuccessfullyRestoreFarm;
			return RedirectToAction("MyFarms", "Farmer");
		}
	}
}
