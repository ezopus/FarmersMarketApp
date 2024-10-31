using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.FarmValidation;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class Farm
    {
        [Key]
        [Comment("Unique identifier of farm")]
        public Guid Id { get; set; }

        [Comment("Farm name.")]
        [MaxLength(FarmNameMaxLength, ErrorMessage = ErrorFarmName)]
        public required string Name { get; set; }

        [Comment("Physical address of farm.")]
        [MaxLength(FarmAddressMaxLength, ErrorMessage = ErrorFarmAddress)]
        public required string Address { get; set; }

        [Comment("City where farm is located or close to.")]
        [MaxLength(FarmCityMaxLength, ErrorMessage = ErrorFarmCity)]
        public required string City { get; set; }

        [Comment("Email address of farm for enquiries.")]
        public string? Email { get; set; }

        [Comment("Phone number of farm visible to general public.")]
        public string? PhoneNumber { get; set; }

        [Comment("Opening hours of farm operations.")]
        public TimeOnly? OpenHours { get; set; }

        [Comment("Closing hours of farm operations.")]
        public TimeOnly? CloseHours { get; set; }

        [Comment("Flag to check if farm is open for business.")]
        public required bool IsOpen { get; set; }

        public virtual ICollection<FarmerFarm> FarmersFarms { get; set; } = new List<FarmerFarm>();

        public virtual ICollection<Product> Products { get; set; } = null!;
    }
}
