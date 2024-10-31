namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
    public class ImportFarmerDto
    {
        public Guid Id { get; set; }

        public required Guid UserId { get; set; }

        public bool HasProducts { get; set; }

        public bool AcceptsDeliveries { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanyRegistrationNumber { get; set; }

        public string? CompanyAddress { get; set; }


    }
}
