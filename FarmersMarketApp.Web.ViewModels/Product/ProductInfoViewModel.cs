using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Web.ViewModels.Product
{
    public class ProductInfoViewModel
    {
        public string Id { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public string UnitType { get; set; } = null!;

        public decimal Price { get; set; }

        public double Size { get; set; }

        public double Quantity { get; set; }

        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public bool HasDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }

        public string? ImageUrl { get; set; }

        public string? Origin { get; set; }

        public string FarmerId { get; set; } = null!;

        public Farmer Farmer { get; set; } = null!;

        public string FarmId { get; set; } = null!;
        public Farm Farm { get; set; } = null!;


    }
}
