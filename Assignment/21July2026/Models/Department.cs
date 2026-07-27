using System.ComponentModel.DataAnnotations;

namespace _21July2026.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department Name is required")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department Head is required")]
        [Display(Name = "Department Head")]
        public string DepartmentHead { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact Number must be 10 digits")]
        [Display(Name = "Head Contact Number")]
        public string HeadContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Head Email")]
        public string HeadEmail { get; set; } = string.Empty;
    }
}
