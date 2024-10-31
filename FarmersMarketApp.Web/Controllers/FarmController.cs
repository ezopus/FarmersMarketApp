using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
