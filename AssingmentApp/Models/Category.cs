using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssingmentApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string? CategoryName { get; set; }
    }
}
