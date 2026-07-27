// validations
using System.ComponentModel.DataAnnotations;

namespace _21July2026Week.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Student name is mendatory")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Student name should be more than 3 character and less than 20 characater")]
        String name { get; set; }
        [Required(ErrorMessage = "Student age is mendatory")]
        [Range(18, 25, ErrorMessage = "Age must be between 18 and 25")]
        int age { get; set; }
        [Required(ErrorMessage = "Student email is mendatory")]
        [EmailAddress(ErrorMessage = "Enter a valid email id")]
        String email { get; set; }
        [Required(ErrorMessage = "Enrolled Course name is mendatory")]
        String course { get; set; }
    }
}
