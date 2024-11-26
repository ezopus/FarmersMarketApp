using FarmersMarketApp.Common.Enums;

namespace FarmersMarketApp.ViewModels.PaymentViewModels
{
	public class PaymentCheckoutViewModel
	{
		public string OrderId { get; set; } = null!;

		public string CustomerId { get; set; } = null!;

		public decimal TotalPrice { get; set; }

		public PaymentType? PaymentType { get; set; }

		public string? CardNumber { get; set; }

		public string? CardHolder { get; set; }

		public string? CardCVV { get; set; }

		public string? CardExpirationDate { get; set; }

	}
}
