using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.DataValidation.ErrorMessages;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.ApplicationUserValidation;

namespace FarmersMarketApp.Web.ViewModels.OrderViewModels
{
	public class OrderCheckoutViewModel
	{
		public string Id { get; set; } = string.Empty;

		public string CustomerId { get; set; } = string.Empty;

		public string CreateDate { get; set; } = string.Empty;

		public int TotalUnitItems => Products.Sum(pr => pr.Amount);

		public decimal TotalDiscount => Products.Sum(pr => pr.Discount * pr.Amount);

		public decimal TotalPrice => Products.Sum(pr => pr.PriceAtPurchase * pr.Amount);

		public OrderStatus OrderStatus { get; set; }

		public IEnumerable<ProductOrderViewModel> Products { get; set; } = new List<ProductOrderViewModel>();

		[StringLength(FirstNameMaxLength,
			MinimumLength = FirstNameMinLength,
			ErrorMessage = ErrorUserFirstName)]
		public string DeliveryFirstName { get; set; }

		[StringLength(LastNameMaxLength,
			MinimumLength = LastNameMinLength,
			ErrorMessage = ErrorUserLastName)]
		public string DeliveryLastName { get; set; }

		[StringLength(AddressMaxLength,
			MinimumLength = AddressMinLength,
			ErrorMessage = ErrorUserAddress)]
		public string DeliveryAddress { get; set; }

		[StringLength(CityMaxLength,
			MinimumLength = CityMinLength,
			ErrorMessage = ErrorUserCity)]
		public string DeliveryCity { get; set; }

		[RegularExpression(PhoneNumberRegex, ErrorMessage = ErrorUserPhoneNumber)]
		public string DeliveryPhoneNumber { get; set; }
	}
}
