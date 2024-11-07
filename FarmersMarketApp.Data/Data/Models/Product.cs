using FarmersMarketApp.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.ProductValidation;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
	public class Product
	{
		[Key]
		[Comment("Unique identifier of each product.")]
		public Guid Id { get; set; }

		[Comment("Product name.")]
		[MaxLength(ProductNameMaxLength, ErrorMessage = ErrorProductName)]
		public required string Name { get; set; }

		[Comment("Description of product in free text format.")]
		[MaxLength(ProductDescriptionMaxLength, ErrorMessage = ErrorProductDescription)]
		public required string Description { get; set; }

		[Comment("Type of unit which product is distributed in - box, carton, bottle, etc.")]
		public required UnitType UnitType { get; set; }

		[Comment("The size of one individual product in one sold unit.")]
		public required double Size { get; set; }

		[Comment("Amount of products in each unit.")]
		public required double Quantity { get; set; }

		[Comment("Weight of product in kilograms")]
		public required double NetWeight { get; set; }

		[Comment("Weight of product with container")]
		public double ShippingWeight { get; set; }

		[Comment("Specific season for product if applicable")]
		public Season? Season { get; set; }

		[Comment("Production date of product.")]
		public required DateTime ProductionDate { get; set; }

		[Comment("Expiration date of product.")]
		public required DateTime ExpirationDate { get; set; }

		[Comment("Category identifier of product.")]
		public required int CategoryId { get; set; }

		[Comment("Price of product for one unit.")]
		[Column(TypeName = "decimal(18,2)")]
		public required decimal Price { get; set; }

		[Comment("Flag if product has active discount.")]
		public required bool HasDiscount { get; set; }

		[Comment("Percentage of discount.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? DiscountPercentage { get; set; }

		[Comment("Unique identifier of farmer who produces current product.")]
		public required Guid FarmerId { get; set; }

		[ForeignKey(nameof(FarmerId))]
		public virtual Farmer Farmer { get; set; } = null!;

		[Comment("Unique identifier of farm where product is made.")]
		public required Guid FarmId { get; set; }

		[ForeignKey(nameof(FarmId))]
		public virtual Farm Farm { get; set; } = null!;

		[Comment("Unique barcode of product.")]
		public string? Barcode { get; set; }

		[Comment("Image url of product.")]
		public string? ImageUrl { get; set; }

		[Comment("Specific origin of product if applicable")]
		public string? Origin { get; set; }

		public virtual ICollection<ProductOrder> ProductsOrders { get; set; } = new List<ProductOrder>();
	}
}
