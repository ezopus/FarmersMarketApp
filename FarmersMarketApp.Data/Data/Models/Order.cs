using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        [Comment("Unique order identifier")]
        public Guid Id { get; set; }

        [Comment("Unique customer identifier")]
        public required Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual ApplicationUser Customer { get; set; } = null!;

        [Comment("Date and time on which order is placed.")]
        public required DateTime CreateDate { get; set; }

        [Comment("Expected date and time on which order is going to be delivered.")]
        public DateTime? DeliveryDate { get; set; }

        [Comment("Total net weight of all items in order.")]
        public required double TotalNetWeight { get; set; }

        [Comment("Total number of units of products contained in order.")]
        public required int TotalUnitItems { get; set; }

        [Comment("Total discount if applicable.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalDiscount { get; set; }

        [Comment("Total price of order including discounts.")]
        [Column(TypeName = "decimal(18,2)")]
        public required decimal TotalPrice { get; set; }

        public virtual Payment? Payment { get; set; }
        public virtual ICollection<ProductOrder> ProductsOrders { get; set; } = new List<ProductOrder>();
    }
}
