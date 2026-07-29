using System.ComponentModel.DataAnnotations;

namespace _28July2026.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Title is required")]
        public string Title { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Course Credits must be greater than 0")]
        public int Credits { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Course Duration must be greater than 0")]
        public int Duration { get; set; }
    }
}

