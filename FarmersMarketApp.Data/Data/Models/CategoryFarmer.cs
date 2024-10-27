using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class CategoryFarmer
    {
        [Comment("Category identifier.")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [Comment("Farmer identifier.")]
        public Guid FarmerId { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public virtual Farmer Farmer { get; set; } = null!;
    }
}
