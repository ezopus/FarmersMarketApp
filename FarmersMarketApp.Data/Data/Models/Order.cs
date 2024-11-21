using FarmersMarketApp.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants.ApplicationUserValidation;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
	public class Order
	{
		[Key]
		[Comment("Unique order identifier")]
		public Guid Id { get; set; }

		[Comment("Unique customer identifier")]
		public required Guid CustomerId { get; set; }

		[ForeignKey(nameof(CustomerId))]
		public virtual ApplicationUser Customer { get; set; } = null!;

		[Comment("Date and time on which order is placed.")]
		public required DateTime CreateDate { get; set; }

		[Comment("Expected date and time on which order is going to be delivered.")]
		public DateTime? DeliveryDate { get; set; }

		[Comment("Unique payment Id gets inserted when order is processed successfully or remains empty if not.")]
		public Guid? PaymentId { get; set; }
		public virtual Payment? Payment { get; set; }
		public virtual ICollection<ProductOrder> ProductsOrders { get; set; } = new List<ProductOrder>();

		[Comment("Status of the current order.")]
		[Column("Status")]
		public Status Status { get; set; }

		[MaxLength(FirstNameMaxLength)]
		[Comment("First name of person for delivery of order.")]
		public string? DeliveryFirstName { get; set; }

		[MaxLength(LastNameMaxLength)]
		[Comment("Last name of person for delivery of order.")]
		public string? DeliveryLastName { get; set; }

		[MaxLength(AddressMaxLength)]
		[Comment("Address for delivery of order.")]
		public string? DeliveryAddress { get; set; }

		[MaxLength(CityMaxLength)]
		[Comment("City for delivery of order.")]
		public string? DeliveryCity { get; set; }

		[MaxLength(PhoneMaxLength)]
		[Comment("Phone number to contact for delivery of order.")]
		public string? DeliveryPhoneNumber { get; set; }

	}

}
