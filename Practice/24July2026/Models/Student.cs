using System.ComponentModel.DataAnnotations;

namespace _24July2026.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Username is requires")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is requires")]
        public string password { get; set; }
    }
}
