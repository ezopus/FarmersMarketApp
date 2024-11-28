using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;

namespace FarmersMarketApp.Services
{
	public class PaymentService : IPaymentService
	{
		private IRepository repository;
		private readonly IUserService userService;

		public PaymentService(
			IRepository repository,
			IUserService userService)
		{
			this.repository = repository;
			this.userService = userService;
		}
		public async Task<string?> CreateNewPayment(string customerId, string orderId, PaymentType paymentType, decimal paymentAmount)
		{
			var newPayment = new Payment()
			{
				Id = Guid.NewGuid(),
				CustomerId = Guid.Parse(customerId),
				OrderId = Guid.Parse(orderId),
				PaymentAmount = paymentAmount,
				PaymentDate = DateTime.Now,
				PaymentType = paymentType,
				IsSuccessful = true,
			};

			await repository.AddAsync(newPayment);
			await repository.SaveChangesAsync();

			return newPayment.Id.ToString();
		}
	}
}
