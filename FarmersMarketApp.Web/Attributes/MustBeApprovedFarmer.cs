using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmersMarketApp.Web.Attributes
{
	public class MustBeApprovedFarmer : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IUserService? userService = context.HttpContext.RequestServices.GetService<IUserService>();

			if (userService != null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			IFarmerService? farmerService = context.HttpContext.RequestServices.GetService<IFarmerService>();

			var currentUserId = context.HttpContext.User.GetId();
			var currentFarmerId = farmerService.GetFarmerIdByUserIdAsync(currentUserId).Result;
			var currentFarmer = farmerService.GetFarmerByIdAsync(currentFarmerId).Result;

			if (userService != null
				&& !string.IsNullOrEmpty(currentFarmerId)
				&& currentFarmer is { IsApproved: false })
			{
				context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
			}
		}
	}
}
