namespace FarmersMarketApp.Infrastructure.Datasets.ImportDTOs
{
    public class ImportFarmDto
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? OpenHours { get; set; }

        public string? CloseHours { get; set; }

        public bool IsOpen { get; set; }

        public required string FarmerId { get; set; }
    }
}
