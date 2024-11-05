using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmerController : BaseController
    {
        private readonly IRepository repository;
        private readonly IFarmService farmService;
        private readonly IFarmerService farmerService;
        private readonly IUserService userService;
        private readonly IProductService productService;

        public FarmerController(
            IRepository repository,
            IUserService userService,
            IFarmerService farmerService,
            IFarmService farmService,
            IProductService productService)
        {
            this.repository = repository;
            this.farmerService = farmerService;
            this.userService = userService;
            this.farmService = farmService;
            this.productService = productService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {



            return View();
        }

        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(FarmerBecomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUserId = User.GetId();
            var currentUser = await userService.GetCurrentUser(Guid.Parse(currentUserId));

            if (currentUser == null || currentUser.IsFarmer)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            await farmerService.BecomeFarmerAsync(currentUser, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        //[MustBeFarmer]
        public async Task<IActionResult> MyFarms()
        {
            var currentUserId = User.GetId();
            var currentFarmerId = await farmerService.GetFarmerIdByUserId(Guid.Parse(currentUserId));
            var farms = await farmService.GetFarmsByFarmerIdAsync(currentFarmerId);

            if (farms == null)
            {
                return RedirectToAction("Add", "Farm");
            }

            return View(farms);
        }

        [HttpGet]
        //[MustBeFarmer]
        public async Task<IActionResult> MyProducts()
        {
            var currentUserId = User.GetId();
            var currentFarmerId = await farmerService.GetFarmerIdByUserId(Guid.Parse(currentUserId));

            var products = await productService.GetProductsByFarmerId(currentFarmerId);

            if (products == null)
            {
                return RedirectToAction("Add", "Product");
            }

            return View(products);
        }

    }
}
