using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IRepository repository;
        private readonly IProductService productService;
        public ProductController(IRepository repository,
            IProductService productService)
        {
            this.repository = repository;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetProductsAsync();

            return View(model);
        }

        [HttpGet]


        private async Task<List<Category>> GetCategories()
        {
            return await repository.AllAsync<Category>().ToListAsync();
        }
    }
}
