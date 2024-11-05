﻿using FarmersMarketApp.Infrastructure.Data.Models;
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
		public async Task<IActionResult> All()
		{
			var model = await productService.GetProductsAsync();

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

		[HttpGet]
		private async Task<List<Category>> GetCategories()
		{
			return await repository.AllAsync<Category>().ToListAsync();
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var model = await productService.GetProductById(id);
			if (model == null)
			{
				return RedirectToAction("All");
			}
			return View(model);
		}


	}
}
