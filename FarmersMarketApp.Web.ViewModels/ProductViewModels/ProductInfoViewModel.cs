using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;

namespace FarmersMarketApp.Web.ViewModels.ProductViewModels
{
	public class ProductInfoViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public string UnitType { get; set; } = null!;

		public decimal Price { get; set; }

		public double Size { get; set; }

		public double Quantity { get; set; }

		public int CategoryId { get; set; }

		public List<Category> Categories { get; set; } = new List<Category>();

		public bool HasDiscount => DiscountPercentage != 0;
		public decimal DiscountPercentage { get; set; }

		public string? ImageUrl { get; set; }

		public string? Origin { get; set; }

		public string FarmerId { get; set; } = null!;

		public FarmerInfoViewModel Farmer { get; set; } = null!;

		public string FarmId { get; set; } = null!;
		public FarmInfoViewModel Farm { get; set; } = null!;

		public string ProductionDate { get; set; } = null!;
		public string ExpirationDate { get; set; } = null!;

		public string DateAdded { get; set; } = null!;

		public bool IsDeleted { get; set; }

	}
}
