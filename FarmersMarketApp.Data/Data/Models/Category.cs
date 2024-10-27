using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("Category identifier.")]
        public int Id { get; set; }

        [Comment("Category name.")]
        public required string Name { get; set; }
    }
}
