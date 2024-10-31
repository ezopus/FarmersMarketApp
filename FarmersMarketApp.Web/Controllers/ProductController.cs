using FarmersMarketApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            var products = context.Products
                .Include(p => p.Farm)
                .Include(p => p.Farmer)
                .Include(p => p.Farmer.User)
                .ToList();

            return View(products);
        }
    }
}
