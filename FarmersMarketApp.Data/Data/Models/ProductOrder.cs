using FarmersMarketApp.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
	public class ProductOrder
	{
		[Comment("Unique order identifier.")]
		public required Guid OrderId { get; set; }

		[ForeignKey(nameof(OrderId))] public Order Order { get; set; } = null!;

		[Comment("Unique product identifier.")]
		public required Guid ProductId { get; set; }

		[ForeignKey(nameof(ProductId))] public Product Product { get; set; } = null!;

		[Comment("Boolean check if product is part of an order which is deleted.")]
		public bool? IsDeleted { get; set; }

		[Comment("Product quantity in order")]
		public int ProductQuantity { get; set; }

		[Comment("Product price at time of purchasing for history purposes.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ProductPriceAtTimeOfOrder { get; set; }

		[Comment("Product discount at time of purchasing for statistical purposes.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ProductDiscountAtTimeOfOrder { get; set; }

		[Comment("Unique farm identifier where product is being made.")]
		public Guid FarmId { get; set; }

		[Comment("Status for each individual product in order")]
		public Status Status { get; set; }

	}
}
