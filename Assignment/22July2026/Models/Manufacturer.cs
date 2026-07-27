using System.ComponentModel.DataAnnotations;

namespace _22July2026.Models
{
    public class Manufacturer
    {
        [Required(ErrorMessage = "Manufacturer Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Manufacturer Name must be between 2 and 50 characters")]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Country must be between 2 and 50 characters")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact Number must be exactly 10 digits")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;
    }
}
