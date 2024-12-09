namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
	public class ImportPaymentDto
	{
		public string Id { get; set; }
		public decimal PaymentAmount { get; set; }
		public int PaymentType { get; set; }
		public string CustomerId { get; set; }
		public string PaymentDate { get; set; }
		public bool IsSuccessful { get; set; }
		public string OrderId { get; set; }
	}
}
