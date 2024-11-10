using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.FarmValidation;

namespace FarmersMarketApp.Web.ViewModels.FarmViewModels
{
	public class AddFarmViewModel
	{
		public string Id { get; set; } = string.Empty;

		[StringLength(FarmNameMaxLength,
			MinimumLength = FarmNameMinLength,
			ErrorMessage = ErrorFarmName)]
		public required string Name { get; set; }

		[StringLength(FarmAddressMaxLength,
			MinimumLength = FarmAddressMinLength,
			ErrorMessage = ErrorFarmAddress)]
		public required string Address { get; set; }

		[StringLength(FarmCityMaxLength,
			MinimumLength = FarmCityMinLength,
			ErrorMessage = ErrorFarmCity)]
		public required string City { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		public string? PhoneNumber { get; set; }

		public string? ImageUrl { get; set; }

		public string? OpenHours { get; set; }

		public string? CloseHours { get; set; }

	}
}
