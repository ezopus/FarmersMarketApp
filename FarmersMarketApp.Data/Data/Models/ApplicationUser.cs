using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.ApplicationUserValidation;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Comment("First name of application user.")]
        [MaxLength(FirstNameMaxLength, ErrorMessage = ErrorUserFirstName)]
        public required string FirstName { get; set; }

        [Comment("Last name of application user.")]
        [MaxLength(LastNameMaxLength, ErrorMessage = ErrorUserLastName)]
        public required string LastName { get; set; }

        [Comment("Role of application user - can be either normal user or admin")]
        public string? Role { get; set; }

        [Comment("Physical address of application user.")]
        [MaxLength(AddressMaxLength, ErrorMessage = ErrorUserAddress)]
        public required string Address { get; set; }


    }
}
