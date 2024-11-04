using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Web.ViewModels.Product
{
    public class ProductInfoViewModel
    {
        public string Id { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }

        public string UnitType { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public double Quantity { get; set; }

        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }

        public bool HasDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }

        public string ImageUrl { get; set; }

        public string Origin { get; set; }

        public string FarmerId { get; set; }

        public Farmer Farmer { get; set; }

        public string FarmId { get; set; }
        public Farm Farm { get; set; }


    }
}
