using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.ProductViewModels;
using FarmersMarketApp.Web.Attributes;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FarmersMarketApp.Common.NotificationConstants;

namespace FarmersMarketApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IFarmService farmService;
        private readonly IFarmerService farmerService;
        //private readonly IOrderService orderService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService,
            IFarmService farmService,
            IFarmerService farmerService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.farmService = farmService;
            this.farmerService = farmerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductsQueryModel model)
        {
            var products = await productService.GetAllActiveProductsWithQueryAsync(
                model.Category,
                model.FarmId,
                model.FarmerId,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ProductsPerPage);

            model.Products = products.Products;
            model.Categories = await categoryService.GetCategoriesAsync();
            model.Farms = await farmService.GetAllFarmNamesAndIdsAsync();
            model.Farmers = await farmerService.GetAllApprovedAndActiveFarmerNamesAndIdsAsync();
            model.TotalProducts = products.TotalProducts;

            return View(model);
        }

        [HttpGet]
        [MustBeFarmer]
        [MustBeApprovedFarmer]
        public async Task<IActionResult> Add()
        {
            //get current userId
            var currentUserId = User.GetId();
            var farmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

            //get all farms where farmer is registered
            var farmerFarms = await farmService.GetFarmNameAndIdForNewProductAsync(farmerId!);

            //check if farmer has farms, if not - redirect him to add a farm
            if (farmerFarms == null || !farmerFarms.Any())
            {
                return RedirectToAction(nameof(Add), "Farm");
            }

            //create a new model and populate drop down options
            var model = new AddProductViewModel
            {
                Categories = await categoryService.GetCategoriesAsync(),
                UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType))),
                Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season))),
                Farms = (List<AddProductFarmOptions>)farmerFarms,
                FarmerId = farmerId!
            };

            return View(model);
        }

        //TODO: check validations
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //TODO: add anti-forgery token here
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            var currentUserId = User.GetId();

            //if user is not logged, redirect him to login
            if (string.IsNullOrEmpty(currentUserId))
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

            //check if current farmer is working on farm to add product to, if no farms are found redirect him to add farm
            var farmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId);
            if (farmerFarms == null || !farmerFarms.Any())
            {
                return RedirectToAction("Add", "Farm");
            }

            //check model state
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetCategoriesAsync();
                model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
                model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
                return View(model);
            }


            //check if current farmer is allowed to add to this farm, if farmer is not allowed redirect him to his own farms
            if (model.FarmerId != currentFarmerId)
            {
                return RedirectToAction("MyFarms", "Farmer");
            }

            //try adding a product
            var result = await productService.CreateProductAsync(model);

            //check if successfully added product
            if (string.IsNullOrEmpty(result))
            {
                TempData[ErrorMessage] = string.Format(FailedAddProduct, model.Name);
                return View(model);
            }

            TempData[SuccessMessage] = string.Format(SuccessfullyAddProduct, model.Name);
            //return product details page to look at newly added product
            return RedirectToAction("Details", "Product", new { id = result });
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            //get product from db, if not found redirect to all products
            var model = await productService.GetProductByIdAsync(id);

            if (model == null || model.IsDeleted)
            {
                return RedirectToAction(nameof(All));
            }

            //try to get farm and farmer of product and check if they are deleted
            var modelFarm = await farmService.GetFarmByIdReadOnlyAsync(model.FarmId);
            var modelFarmer = await farmerService.GetFarmerByIdAsync(model.FarmerId);

            if (modelFarm == null ||
                modelFarmer == null ||
                modelFarm.IsDeleted ||
                modelFarmer.IsDeleted)
            {
                return RedirectToAction(nameof(All));
            }
            model.Farm = modelFarm;
            model.Farmer = modelFarmer;

            return View(model);
        }

        [HttpGet]
        [MustBeFarmer]
        [MustBeApprovedFarmer]
        public async Task<IActionResult> Edit(string productId)
        {
            var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(User.GetId());

            //get model from db, if not found redirect to all products
            var model = await productService.GetProductToEditByIdAsync(productId);
            if (model == null)
            {
                return RedirectToAction("All");
            }

            //get all farms of farmer where he is employed
            var currentFarmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId!);

            //check if any farm where farmer works is producing this product
            if (currentFarmerFarms == null || !currentFarmerFarms.Any(f => f.Equals(model.FarmId, StringComparison.CurrentCultureIgnoreCase)))
            {
                return RedirectToAction("MyProducts", "Farmer");
            }

            model.Categories = await categoryService.GetCategoriesAsync();
            model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
            model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
            model.Farms = await farmService.GetFarmNameAndIdForNewProductAsync(currentFarmerId);

            return View(model);
        }

        [HttpPost]
        [MustBeFarmer]
        [MustBeApprovedFarmer]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AddProductViewModel model)
        {
            var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(User.GetId());

            //get all farms of farmer where he is employed
            var currentFarmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(currentFarmerId);

            //check if any farm where farmer works is producing this product
            if (currentFarmerFarms == null || !currentFarmerFarms.Any(f => f.Equals(model.FarmId, StringComparison.CurrentCultureIgnoreCase)))
            {
                return RedirectToAction("MyProducts", "Farmer");
            }

            //check model state on post
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetCategoriesAsync();
                model.UnitTypes = new List<UnitType>((UnitType[])Enum.GetValues(typeof(UnitType)));
                model.Seasons = new List<Season>((Season[])Enum.GetValues(typeof(Season)));
                model.Farms = await farmService.GetFarmNameAndIdForNewProductAsync(currentFarmerId);
                return View(model);
            }

            //try to edit product
            var result = await productService.UpdateEditedProductAsync(model);

            //if edit fails return view
            if (result == null)
            {
                TempData[ErrorMessage] = string.Format(FailedEditProduct, model.Name);
                return View(model);
            }

            TempData[SuccessMessage] = string.Format(SuccessfullyEditProduct, model.Name);
            //return details of edited product to verify edit is successful
            return RedirectToAction("Details", "Product", new { id = model.Id });
        }
    }
}
