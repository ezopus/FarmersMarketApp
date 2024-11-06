using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmersMarketApp.Web.Attributes
{
    public class MustBeFarmer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IUserService? userService = context.HttpContext.RequestServices.GetService<IUserService>();

            if (userService != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (userService != null
                && userService.IsUserFarmer(
                    Guid.Parse(
                        context.HttpContext.User.GetId()
                        )
                    ).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
