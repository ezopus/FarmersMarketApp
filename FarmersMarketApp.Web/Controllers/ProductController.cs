using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(Guid? farmerId, string? farmerFullName)
        {
            if (farmerId.HasValue && farmerFullName != null)
            {
                ViewData["farmerId"] = farmerId;
                ViewData["farmerFullName"] = farmerFullName;
            }

            var model = farmerId.HasValue
                ? await productService.GetProductsByFarmerIdAsync(farmerId.Value)
                : await productService.GetProductsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        //TODO: Implement categories
        [HttpGet]
        private async Task<List<Category>> GetCategories()
        {
            return await repository.AllAsync<Category>().ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await productService.GetProductByIdAsync(id);
            if (model == null)
            {
                return RedirectToAction("All");
            }
            return View(model);
        }

        //TODO: Implement product edit
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid productId)
        {
            return RedirectToAction(nameof(Details), new { productId });
        }


    }
}
