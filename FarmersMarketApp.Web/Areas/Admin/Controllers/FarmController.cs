using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class FarmController : Controller
	{
		private readonly IFarmService farmService;

		public FarmController(IFarmService farmService)
		{
			this.farmService = farmService;
		}
		public async Task<IActionResult> Manage()
		{
			var farms = await farmService.GetAllFarmsAsync();

			return View(farms);
		}

		public async Task<IActionResult> Restore(string farmId)
		{
			var result = await farmService.RestoreFarmByFarmIdAsync(farmId);

			return RedirectToAction(nameof(Manage));
		}
		public async Task<IActionResult> Delete(string farmId)
		{
			var result = await farmService.SetFarmIsDeletedByFarmIdAsync(farmId);

			return RedirectToAction(nameof(Manage));
		}
	}
}
