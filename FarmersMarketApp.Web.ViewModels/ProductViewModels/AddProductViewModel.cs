using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.ProductValidation;

namespace FarmersMarketApp.Web.ViewModels.ProductViewModels
{
	public class AddProductViewModel
	{
		[StringLength(ProductNameMaxLength,
			MinimumLength = ProductNameMinLength,
			ErrorMessage = ErrorProductName)]
		public required string Name { get; set; }

		[StringLength(ProductDescriptionMaxLength,
			MinimumLength = ProductDescriptionMinLength,
			ErrorMessage = ErrorProductDescription)]
		public required string Description { get; set; }

		public required string UnitType { get; set; }

		[Range(ProductSizeMin,
			ProductSizeMax,
			ErrorMessage = ErrorProductSize)]
		public required double Size { get; set; }

		[Range(ProductQuantityMin,
			ProductQuantityMax,
			ErrorMessage = ErrorProductQuantity)]
		public required double Quantity { get; set; }

		[Range(ProductWeightMin,
			ProductWeightMax,
			ErrorMessage = ErrorProductWeight)]
		public required double NetWeight { get; set; }

		public double ShippingWeight { get; set; }

		public string? Season { get; set; }

		public required string ProductionDate { get; set; }
		public required string ExpirationDate { get; set; }

		public required int CategoryId { get; set; }

		[Range(typeof(decimal), ProductPriceMin,
			ProductPriceMax,
			ErrorMessage = ErrorProductPrice)]
		public required decimal Price { get; set; }

		public bool? HasDiscount { get; set; }

		//percentage cannot be more than 100 and less than 0.01, no point of constants
		[Range(0.01, 100)]
		public double DiscountPercentage { get; set; }

		public string? Barcode { get; set; }

		public string? Origin { get; set; }

	}
}
