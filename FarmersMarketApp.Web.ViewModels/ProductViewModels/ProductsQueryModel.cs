﻿using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;

namespace FarmersMarketApp.Web.ViewModels.ProductViewModels
{
	public class ProductsQueryModel
	{
		public int? Category { get; set; }

		public string? SearchTerm { get; set; }

		public string? FarmId { get; set; }

		public string? FarmerId { get; set; }

		public ProductSorting Sorting { get; set; }

		public int CurrentPage { get; set; } = 1;

		public int ProductsPerPage { get; set; } = 8;

		public IEnumerable<ProductInfoViewModel> Products { get; set; } = new List<ProductInfoViewModel>();

		public IEnumerable<Category> Categories { get; set; } = new List<Category>();

		public IEnumerable<FarmsForDropDown> Farms { get; set; } = new List<FarmsForDropDown>();

		public int TotalProducts { get; set; }

	}
}
