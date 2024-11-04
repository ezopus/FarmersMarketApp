using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
