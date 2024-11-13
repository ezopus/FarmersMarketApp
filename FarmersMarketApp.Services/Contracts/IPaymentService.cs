using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IPaymentService
	{
		Task<string?> CreateNewPayment(string customerId, string orderId, PaymentType paymentType, decimal paymentAmount, Order order);
	}
}
