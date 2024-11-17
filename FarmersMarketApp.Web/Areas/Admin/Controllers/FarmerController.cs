using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		public async Task<IActionResult> Restore(string farmerId)
		{
			var result = await farmerService.RestoreFarmerByIdAsync(farmerId);

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> RestoreAll(string farmerId)
		{
			var result = await farmerService.RestoreFarmerFarmsProductsByIdAsync(farmerId);

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> Delete(string farmerId)
		{
			var result = await farmerService.SetFarmerIsDeletedByIdAsync(farmerId);

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> DeleteAll(string farmerId)
		{
			var result = await farmerService.SetFarmerFarmsProductsIsDeletedByIdAsync(farmerId);

			return RedirectToAction(nameof(Manage));
		}
	}
}
