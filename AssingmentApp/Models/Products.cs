using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssingmentApp.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? CategoryName { get; set; }
    }
}
