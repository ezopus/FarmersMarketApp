using FarmersMarketApp.Infrastructure.Data.Models.Enums;
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

        public required UnitType UnitType { get; set; }
        public required int Quantity { get; set; }
        public required double Weight { get; set; }

        public required decimal Price { get; set; }

        public required bool HasDiscount { get; set; }

        public int? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice
        {
            get
            {
                if (HasDiscount)
                {
                    return Price * (DiscountPercentage / 100m);
                }

                return Price;
            }
        }

        public required Guid FarmerId { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; } = null!;

        public Season? Season { get; set; }

        public required DateTime ProductionDate { get; set; }
        public required DateTime ExpirationDate { get; set; }

        public required int CategoryId { get; set; }

        public string? Barcode { get; set; }

        public string? ImageUrl { get; set; }

        public required string Origin { get; set; }


    }
}
