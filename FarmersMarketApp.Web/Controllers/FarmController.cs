using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmController : BaseController
    {
        private readonly IRepository repository;
        private readonly IFarmService farmService;
        public FarmController(
            IRepository repository,
            IFarmService farmService)
        {
            this.repository = repository;
            this.farmService = farmService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var farms = await farmService.GetFarmsAsync();
            return View(farms);
        }
    }
}
