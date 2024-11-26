using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FarmersMarketApp.Common.NotificationConstants;

namespace FarmersMarketApp.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class FarmerController : Controller
	{
		private readonly IFarmerService farmerService;

		public FarmerController(IFarmerService farmerService)
		{
			this.farmerService = farmerService;
		}
		public async Task<IActionResult> Manage()
		{
			var farmers = await farmerService.GetAllFarmersAsync();

			return View(farmers);
		}

		public async Task<IActionResult> Approve(string farmerId)
		{
			var result = await farmerService.ApproveFarmerByFarmerIdAsync(farmerId);

			if (result)
			{
				TempData[SuccessMessage] = SuccessfullyApproveFarmer;
			}
			else
			{
				TempData[ErrorMessage] = FailedApproveFarmer;
			}

			return RedirectToAction(nameof(Manage));
		}

		public async Task<IActionResult> Restore(string farmerId)
		{
			var result = await farmerService.RestoreFarmerByIdAsync(farmerId);

			if (result)
			{
				TempData[SuccessMessage] = SuccessfullyRestoreFarmer;
			}
			else
			{
				TempData[ErrorMessage] = FailedRestoreFarmer;
			}

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> RestoreAll(string farmerId)
		{
			var result = await farmerService.RestoreFarmerFarmsProductsByIdAsync(farmerId);

			if (result)
			{
				TempData[SuccessMessage] = SuccessfullyRestoreFarmerEntities;
			}
			else
			{
				TempData[ErrorMessage] = FailedRestoreFarmer;
			}

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> Delete(string farmerId)
		{
			var result = await farmerService.SetFarmerIsDeletedByIdAsync(farmerId);

			if (result)
			{
				TempData[SuccessMessage] = SuccessfullyDeleteFarmer;
			}
			else
			{
				TempData[ErrorMessage] = FailedDeleteFarmer;
			}

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> DeleteAll(string farmerId)
		{
			var result = await farmerService.SetFarmerFarmsProductsIsDeletedByIdAsync(farmerId);

			if (result)
			{
				TempData[SuccessMessage] = SuccessfullyDeleteFarmerEntities;
			}
			else
			{
				TempData[ErrorMessage] = FailedDeleteFarmer;
			}

			return RedirectToAction(nameof(Manage));
		}
	}
}
