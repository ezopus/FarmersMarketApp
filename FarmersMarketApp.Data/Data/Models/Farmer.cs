using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class Farmer : ApplicationUser
    {
        [Comment("Flag to show if farmer has any products for sale.")]
        public bool HasProducts { get; set; }

        [Comment("Flag to show if farmer is currently accepting deliveries.")]
        public bool AcceptsDeliveries { get; set; }

        [Comment("Unique identifier of farm which current farmer works on and produces products.")]
        public Guid FarmId { get; set; }

        public Farm Farm { get; set; } = null!;

        public ICollection<CategoryFarmer> CategoriesFarmers { get; set; } = new List<CategoryFarmer>();
    }
}
