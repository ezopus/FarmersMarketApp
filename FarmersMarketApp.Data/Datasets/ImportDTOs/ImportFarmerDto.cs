namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
	public class ImportFarmerDto
	{
		public Guid Id { get; set; }

		public required Guid UserId { get; set; }

		public bool HasProducts { get; set; }

		public string? CompanyName { get; set; }

		public string? CompanyRegistrationNumber { get; set; }

		public string? CompanyAddress { get; set; }

		public bool IsApproved { get; set; }

		public bool IsDeleted { get; set; }

		public string? ImageUrl { get; set; }

		public string? DateApproved { get; set; }

	}
}
