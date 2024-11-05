using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Web.ViewModels.FarmViewModels
{
    public class FarmInfoViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? OpenHours { get; set; }

        public string? CloseHours { get; set; }

        public bool IsOpen { get; set; }

        public virtual ICollection<FarmerFarm> FarmersFarms { get; set; } = new List<FarmerFarm>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
