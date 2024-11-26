namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
	public class ImportProductDto
	{
		public required string Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public required string UnitType { get; set; }
		public required double Quantity { get; set; }
		public required double NetWeight { get; set; }
		public string? Season { get; set; }
		public required string ProductionDate { get; set; }
		public required string ExpirationDate { get; set; }
		public required int CategoryId { get; set; }
		public required decimal Price { get; set; }
		public bool HasDiscount { get; set; } = false;
		public decimal? DiscountPercentage { get; set; }
		public required string FarmerId { get; set; }
		public required string FarmId { get; set; }
		public string? Barcode { get; set; }
		public string? ImageUrl { get; set; }
		public string? Origin { get; set; }
		public required string DateAdded { get; set; }

	}
}
