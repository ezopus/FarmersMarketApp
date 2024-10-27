using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class Farmer : ApplicationUser
    {
        [Comment("Flag to show if farmer has any products for sale.")]
        public bool HasProducts { get; set; }

        [Comment("Flag to show if farmer is currently accepting deliveries.")]
        public bool AcceptsDeliveries { get; set; }

        [Comment("Company name of farmer for billing purposes.")]
        public string? CompanyName { get; set; }

        [Comment("Company registration number for VAT and tax purposes.")]
        public string? CompanyRegistrationNumber { get; set; }

        [Comment("Company address for billing and shipping purposes.")]
        public string? CompanyAddress { get; set; }

        public virtual Farm Farm { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<CategoryFarmer> CategoriesFarmers { get; set; } = new List<CategoryFarmer>();
    }
}
