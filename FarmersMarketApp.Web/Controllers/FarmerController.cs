﻿using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;

namespace FarmersMarketApp.Web.Controllers
{
	public class FarmerController : BaseController
	{
		private readonly IFarmService farmService;
		private readonly IFarmerService farmerService;
		private readonly IUserService userService;
		private readonly IProductService productService;

		public FarmerController(
			IUserService userService,
			IFarmerService farmerService,
			IFarmService farmService,
			IProductService productService)
		{
			this.farmerService = farmerService;
			this.userService = userService;
			this.farmService = farmService;
			this.productService = productService;
		}

		//get all farmers in the market
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var farmers = await farmerService.GetAllFarmersAsync();

			return View(farmers);
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			//get current user id
			var currentUserId = User.GetId();

			//check if user is logged in
			if (string.IsNullOrEmpty(currentUserId))
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			var isFarmer = await userService.IsUserFarmerAsync(currentUserId);

			//if user is already a farmer redirect to my farms
			if (isFarmer)
			{
				return RedirectToAction(nameof(MyFarms), "Farmer");
			}

			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		//todo: add anti-forgery token here
		public async Task<IActionResult> Become(FarmerBecomeViewModel model)
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if user is farmer, if he already is, redirect him to his farms
			if (!string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("MyFarms", "Farmer");
			}

			//check model state
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//check if accept deliveries is pressed and set error if not
			//workaround to not have any button selected when initial loading of page
			if (model.AcceptsDeliveries == null)
			{
				ModelState.AddModelError(nameof(model.AcceptsDeliveries), ErrorAcceptDeliveriesNotSelected);
				return View(model);
			}

			//async create new farmer entity
			var result = await farmerService.BecomeFarmerAsync(currentUserId, model);

			if (string.IsNullOrEmpty(result))
			{
				return View(model);
			}

			//redirect to my farms
			return RedirectToAction(nameof(MyFarms));
		}

		[HttpGet]
		//[MustBeFarmer]
		public async Task<IActionResult> MyFarms()
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get all farms for current farmer
			var farms = await farmService.GetAllFarmsByFarmerIdAsync(currentFarmerId);

			//check if farms list is empty, if yes redirect to add farm
			if (farms == null || !farms.Any())
			{
				return RedirectToAction("Add", "Farm");
			}

			//return model with all farms of current farmer
			return View(farms);
		}

		[HttpGet]
		//[MustBeFarmer]
		public async Task<IActionResult> MyProducts()
		{
			//get current user id
			var currentUserId = User.GetId();
			var currentFarmerId = await farmerService.GetFarmerIdByUserIdAsync(currentUserId);

			//check if farmer exists, redirect to become one if not
			if (string.IsNullOrEmpty(currentFarmerId))
			{
				return RedirectToAction("Become", "Farmer");
			}

			//get all products for current farmer
			var products = await productService.GetProductsByFarmerIdAsync(currentFarmerId);

			//check if products list is empty, if yes redirect to add product
			if (products == null || !products.Any())
			{
				return RedirectToAction("Add", "Product");
			}

			//return model with all farms to render view
			return View(products);
		}

	}
}
