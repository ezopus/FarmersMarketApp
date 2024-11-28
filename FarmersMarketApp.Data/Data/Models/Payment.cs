using FarmersMarketApp.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
	public class Payment
	{
		[Key]
		[Comment("Unique payment identifier.")]
		public Guid Id { get; set; }

		[Comment("Total payment amount.")]
		[Column(TypeName = "decimal(18,2)")]
		public required decimal PaymentAmount { get; set; }

		[Comment("Type of payment method used.")]
		public PaymentType PaymentType { get; set; } = Enum.Parse<PaymentType>("CashOnDemand");

		[Comment("Unique customer identifier.")]
		public required Guid CustomerId { get; set; }

		[ForeignKey(nameof(CustomerId))]
		public virtual ApplicationUser Customer { get; set; } = null!;

		[Comment("Date and time on which payment is made.")]
		public required DateTime PaymentDate { get; set; }

		[Comment("Flag if payment is successful.")]
		public bool IsSuccessful { get; set; }

		[Comment("Unique order identifier for the payment record.")]
		public Guid OrderId { get; set; }

		//[ForeignKey(nameof(OrderId))]
		public virtual Order? Order { get; set; }
	}
}
