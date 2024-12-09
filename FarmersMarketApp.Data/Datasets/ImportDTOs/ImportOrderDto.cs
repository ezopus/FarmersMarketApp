namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
	public class ImportOrderDto
	{
		public string Id { get; set; }
		public string CustomerId { get; set; }
		public string CreateDate { get; set; }
		public string DeliveryDate { get; set; }
		public int Status { get; set; }
		public string PaymentId { get; set; }
		public string DeliveryAddress { get; set; }
		public string DeliveryCity { get; set; }
		public string DeliveryFirstName { get; set; }
		public string DeliveryLastName { get; set; }
		public string DeliveryPhoneNumber { get; set; }
	}
}
