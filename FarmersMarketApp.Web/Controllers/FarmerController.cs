using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
