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
		public async Task<IActionResult> GetFarmInfo(string farmerId)
		{
			//get all farms where the farmer is participating
			var farms = await farmService.GetFarmNameAndIdForNewProductAsync(farmerId);

			//the api will return this object
			Dictionary<string, object> farmsForApi = new();

			//if there are no farms, return a not found response
			//todo: update js script to handle logic correctly when no response is found
			if (farms == null)
			{
				return NotFound();
			}

			//add farm info to json object
			foreach (var f in farms)
			{
				if (string.IsNullOrEmpty(f.ImageUrl))
				{
					f.ImageUrl = "/img/no-image.png";
				}
				farmsForApi.Add(f.Id.ToString(), new { f.Name, f.Address, f.City, f.ImageUrl });
			}

			//return object with three random farms and their info
			return Ok(farmsForApi);
		}

		[HttpGet]
		public IActionResult Index()
		{
			//test info if api loads correctly
			return Ok(new { farmId = "test" });
		}
	}
}
