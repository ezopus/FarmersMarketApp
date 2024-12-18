﻿using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.ViewModels.FarmerViewModels;
using FarmersMarketApp.ViewModels.FarmViewModels;

namespace FarmersMarketApp.ViewModels.AdminViewModels
{
	public class ProductInfoAdminViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		public int CategoryId { get; set; }

		public List<Category> Categories { get; set; } = new List<Category>();

		public bool HasDiscount => DiscountPercentage != 0;
		public decimal DiscountPercentage { get; set; }

		public string? ImageUrl { get; set; }

		public string FarmerId { get; set; } = null!;

		public FarmerInfoViewModel Farmer { get; set; } = null!;

		public string FarmId { get; set; } = null!;
		public FarmInfoViewModel Farm { get; set; } = null!;

		public bool IsDeleted { get; set; }
	}
}
