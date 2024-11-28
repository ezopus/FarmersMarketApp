using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
	public class Farmer
	{
		[Key]
		[Comment("Farmer unique identifier.")]
		public Guid Id { get; set; }

		[Comment("Foreign key to general application user.")]
		public required Guid UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual ApplicationUser User { get; set; } = null!;

		[Comment("Flag to show if farmer has any products for sale.")]
		public bool HasProducts { get; set; }

		[Comment("Company name of farmer for billing purposes.")]
		public string? CompanyName { get; set; }

		[Comment("Company registration number for VAT and tax purposes.")]
		public string? CompanyRegistrationNumber { get; set; }

		[Comment("Company address for billing and shipping purposes.")]
		public string? CompanyAddress { get; set; }

		[Comment("Image URL of farmer.")]
		public string? ImageUrl { get; set; }
		public virtual ICollection<FarmerFarm> FarmersFarms { get; set; } = new List<FarmerFarm>();

		[Comment("Boolean flag if farmer decides to deactivate his account.")]
		public bool IsDeleted { get; set; }

		[Comment("Boolean flag to show if farmer has passed approval by administrator.")]
		public bool IsApproved { get; set; }

		[Comment("Date and time when administrator has approved farmer.")]
		public DateTime? DateApproved { get; set; }
	}
}
