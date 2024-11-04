using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
