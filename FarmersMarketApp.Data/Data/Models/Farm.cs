using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public required string PhoneNumber { get; set; }

        [Comment("Opening hours of farm operations.")]
        public required DateTime OpenHours { get; set; }

        [Comment("Closing hours of farm operations.")]
        public required DateTime CloseHours { get; set; }

        [Comment("Flag to check if farm is open for business.")]
        public required bool IsOpen { get; set; }

        [Comment("Unique identifier of farmer who owns current farm.")]
        public required Guid FarmerId { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public virtual Farmer Farmer { get; set; } = null!;

        public virtual List<Product> Products { get; set; } = null!;
    }
}
