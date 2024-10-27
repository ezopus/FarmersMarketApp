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

        public bool? IsDeleted { get; set; }
    }
}
