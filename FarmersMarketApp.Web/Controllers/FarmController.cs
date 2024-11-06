using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmController : BaseController
    {
        private readonly IRepository repository;
        private readonly IFarmService farmService;
        private readonly IFarmerService farmerService;
        public FarmController(
            IRepository repository,
            IFarmService farmService,
            IFarmerService farmerService)
        {
            this.repository = repository;
            this.farmService = farmService;
            this.farmerService = farmerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(Guid? farmerId)
        {
            var currentUserId = User.GetId();
            var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(Guid.Parse(currentUserId));

            if (currentFarmerId != null)
            {
                ViewData["farmerId"] = currentFarmerId.ToString();
            }

            //check if route has farmer id parameters and if yes show only farms by one farmer
            //TODO: add switch case for filtration by category 
            var farms = farmerId.HasValue
                ? await farmService.GetFarmsByFarmerIdAsync(farmerId.Value)
                : await farmService.GetFarmsAsync();

            return View(farms);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid farmId)
        {
            var model = await farmService.GetFarmByIdAsync(farmId);

            return View(model);
        }
    }
}
