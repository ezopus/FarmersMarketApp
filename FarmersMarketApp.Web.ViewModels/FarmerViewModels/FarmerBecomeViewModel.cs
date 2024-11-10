using System.ComponentModel.DataAnnotations;

namespace FarmersMarketApp.Web.ViewModels.FarmerViewModels
{
	using static Common.DataValidation.ErrorMessages;
	using static Common.DataValidation.ValidationConstants.FarmerValidation;
	public class FarmerBecomeViewModel
	{
		public string UserId { get; set; } = string.Empty;

		public bool HasProducts { get; set; } = false;

		public bool? AcceptsDeliveries { get; set; }

		[StringLength(CompanyNameMaxLength,
			MinimumLength = CompanyNameMinLength,
			ErrorMessage = ErrorFarmerCompanyName)]
		public string CompanyName { get; set; } = null!;

		[StringLength(CompanyRegistrationNumberMaxLength,
			MinimumLength = CompanyRegistrationNumberMinLength,
			ErrorMessage = ErrorFarmerCompanyRegistrationNumberLength)]
		[RegularExpression(CompanyRegistrationNumberRegex, ErrorMessage = ErrorFarmerCompanyRegistrationNumberType)]
		public string CompanyRegistrationNumber { get; set; } = null!;

		[StringLength(CompanyAddressMaxLength,
			MinimumLength = CompanyAddressMinLength,
			ErrorMessage = ErrorFarmerCompanyAddress)]
		public string CompanyAddress { get; set; } = null!;

		//TODO: Try to implement farmer category from the registration
		//public List<int> Categories { get; set; }
	}
}
