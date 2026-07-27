using System.ComponentModel.DataAnnotations;

namespace _22July2026.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(10, 100000, ErrorMessage = "Price must be between 10 and 100000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category name is mandatory")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Stock is mandatory")]
        public int Stock { get; set; }
    }
}
