using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FarmApiController : ControllerBase
	{
		private readonly IFarmService farmService;

		public FarmApiController(IFarmService farmService)
		{
			this.farmService = farmService;
		}
		// API action to get a specific farm's information
		[HttpGet("info/{farmerId}")]
		public async Task<IActionResult> GetFarmInfo(Guid farmerId)
		{
			var farms = await farmService.GetFarmNameAndIdForNewProductAsync(farmerId);
			Dictionary<Guid, object> farmsForApi = new();

			foreach (var f in farms)
			{
				farmsForApi.Add(f.Id, new { f.Name, f.Address, f.City, f.ImageUrl });
			}

			return Ok(farmsForApi);
		}

		[HttpGet]
		public IActionResult Index()
		{
			return Ok(new { farmId = "test" });
		}
	}
}
