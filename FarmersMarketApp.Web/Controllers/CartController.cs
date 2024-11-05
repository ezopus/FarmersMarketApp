using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult MyCart()
        {
            return View();
        }
    }
}
