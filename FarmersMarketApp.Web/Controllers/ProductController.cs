using FarmersMarketApp.Infrastructure.Data;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.Product;
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
                .Select(p => new ProductInfoViewModel()
                {
                    ProductName = p.Name,
                    Description = p.Description,
                    FarmId = p.FarmId.ToString(),
                    Farm = p.Farm,
                    FarmerId = p.FarmerId.ToString(),
                    Farmer = p.Farmer,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    DiscountPercentage = p.DiscountPercentage ?? 0,
                    UnitType = p.UnitType.ToString(),
                    Size = p.Size,
                    Quantity = p.Quantity,
                    Origin = p.Origin ?? "",
                    ImageUrl = p.ImageUrl ?? "",
                })
                .ToList();

            return View(products);
        }

        private async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }
    }
}
