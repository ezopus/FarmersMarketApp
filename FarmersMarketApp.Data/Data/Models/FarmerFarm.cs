using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class FarmerFarm
    {
        [Comment("Unique farmer identifier.")]
        public required Guid FarmerId { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer? Farmer { get; set; }

        [Comment("Unique farm identifier.")]
        public required Guid FarmId { get; set; }

        [ForeignKey(nameof(FarmId))]
        public Farm? Farm { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
