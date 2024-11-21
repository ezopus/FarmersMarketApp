using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
	[Route("api/farmer")]
	[ApiController]
	//[Authorize]
	public class FarmerApiController : ControllerBase
	{
		private readonly IFarmerService farmerService;

		public FarmerApiController(IFarmerService farmerService)
		{
			this.farmerService = farmerService;
		}

		[HttpGet]
		[Route("complete")]
		public async Task<bool> CompleteOrder([FromBody] string farmerId, string orderId)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return false;
			}

			var result = await farmerService.CompleteOrderByOrderIdAsync(currentFarmerId, orderId);

			return result;
		}

		[HttpGet]
		[Route("cancel/{orderId}")]
		public async Task<bool> CancelOrder(string orderId)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return false;
			}

			var result = await farmerService.CancelOrderByOrderIdAsync(currentFarmerId, orderId);

			return true;
		}
	}
}
