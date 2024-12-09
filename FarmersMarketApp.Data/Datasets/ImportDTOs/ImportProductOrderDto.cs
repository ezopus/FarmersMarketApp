namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
	public class ImportProductOrderDto
	{
		public string OrderId { get; set; }
		public ImportProduct[] Products { get; set; }
	}

	public class ImportProduct
	{
		public string ProductId { get; set; }
		public bool? IsDeleted { get; set; }
		public int ProductQuantity { get; set; }
		public decimal ProductPriceAtTimeOfOrder { get; set; }
		public decimal ProductDiscountAtTimeOfOrder { get; set; }
		public string FarmId { get; set; }
		public int Status { get; set; }
	}
}
