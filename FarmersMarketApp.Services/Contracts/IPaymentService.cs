using FarmersMarketApp.Common.Enums;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IPaymentService
	{
		Task<string?> CreateNewPayment(string customerId, string orderId, PaymentType paymentType, decimal paymentAmount);
	}
}
