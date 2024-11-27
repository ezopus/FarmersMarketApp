using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.ProductValidation;

namespace FarmersMarketApp.ViewModels.ProductViewModels
{
	public class AddProductViewModel
	{
		public string Id { get; set; } = string.Empty;

		[StringLength(ProductNameMaxLength,
			MinimumLength = ProductNameMinLength,
			ErrorMessage = ErrorProductName)]
		public string Name { get; set; } = string.Empty;

		[StringLength(ProductDescriptionMaxLength,
			MinimumLength = ProductDescriptionMinLength,
			ErrorMessage = ErrorProductDescription)]
		public string Description { get; set; } = string.Empty;

		public string? ImageUrl { get; set; }

		public string UnitType { get; set; } = string.Empty;
		public IEnumerable<UnitType> UnitTypes { get; set; } = new List<UnitType>();

		[Range(ProductQuantityMin,
			ProductQuantityMax,
			ErrorMessage = ErrorProductQuantity)]
		public double Quantity { get; set; }

		[Range(ProductWeightMin,
			ProductWeightMax,
			ErrorMessage = ErrorProductWeight)]
		public double NetWeight { get; set; }

		public string? Season { get; set; }
		public IEnumerable<Season> Seasons { get; set; } = new List<Season>();

		public string ProductionDate { get; set; } = string.Empty;
		public string ExpirationDate { get; set; } = string.Empty;

		public int CategoryId { get; set; }
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();

		[Range(typeof(decimal), ProductPriceMin,
			ProductPriceMax,
			ErrorMessage = ErrorProductPrice)]
		public decimal Price { get; set; }

		public bool HasDiscount { get; set; }

		//percentage cannot be more than 100 and less than 1 percent, no point of constants
		[Range(0.0, 100.0)]
		public decimal DiscountPercentage { get; set; }

		public string? Barcode { get; set; }

		public string? Origin { get; set; }

		public string FarmId { get; set; } = string.Empty;

		public IEnumerable<AddProductFarmOptions> Farms { get; set; } = new List<AddProductFarmOptions>();

		public string FarmerId { get; set; } = string.Empty;

	}
}
