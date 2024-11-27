using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmersMarketApp.Web.Attributes
{
    public class MustBeApprovedFarmer : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IFarmerService? farmerService = context.HttpContext.RequestServices.GetService<IFarmerService>();

            if (farmerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return;
            }

            var currentUserId = context.HttpContext.User.GetId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);
            if (string.IsNullOrEmpty(currentFarmerId))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            var currentFarmer = await farmerService.GetFarmerByIdAsync(currentFarmerId);
            if (currentFarmer == null || !currentFarmer.IsApproved)
            {
                // Redirect to an appropriate page if the farmer is not approved
                context.Result = new StatusCodeResult(StatusCodes.Status405MethodNotAllowed);
                return;
            }

            await next();
        }
    }
}
