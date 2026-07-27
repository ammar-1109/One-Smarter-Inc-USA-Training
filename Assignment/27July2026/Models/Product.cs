using System.ComponentModel.DataAnnotations;

namespace _27July2026.Models
{
    public class Product
    {
        [Required(ErrorMessage ="Product ID is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Product Price is required")]


        public int Price { get; set; }
        [Required(ErrorMessage = "Product Stock is required")]

        public int Stock {  get; set; }
    }
}
