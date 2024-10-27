using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
