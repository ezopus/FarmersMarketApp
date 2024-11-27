using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmersMarketApp.Web.Attributes
{
    public class MustBeFarmer : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IUserService? userService = context.HttpContext.RequestServices.GetService<IUserService>();

            if (userService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return;
            }

            bool isFarmer = await userService.IsUserFarmerAsync(context.HttpContext.User.GetId());

            if (!isFarmer)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            await next();
        }
    }
}
