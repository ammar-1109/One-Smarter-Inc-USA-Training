using System.ComponentModel.DataAnnotations;

namespace _22July2026.Models
{
    public class Automobile
    {
        [Required(ErrorMessage = "Vehicle ID is required")]
        [Display(Name = "Vehicle ID")]
        [RegularExpression(@"^[A-Za-z0-9]{5,10}$", ErrorMessage = "Vehicle ID must be 5-10 alphanumeric characters")]
        public string VehicleId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vehicle Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Vehicle Name must be between 2 and 50 characters")]
        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Brand must be between 2 and 30 characters")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model Year is required")]
        [Range(1900, 2026, ErrorMessage = "Model Year must be between 1900 and 2026")]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1000, 10000000, ErrorMessage = "Price must be between 1000 and 10000000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Fuel Type is required")]
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; } = string.Empty;
    }
}
