using Microsoft.AspNetCore.Mvc;
using _25Jul.Models;

namespace _25Jul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new()
        {
            new Student { Id = 1, Name = "Ammar", Age = 35, Department = "Computer Science" },
            new Student { Id = 2, Name = "Aisha", Age = 20, Department = "Information Technology" },
            new Student { Id = 3, Name = "Rahul", Age = 21, Department = "Mechanical Engineering" },
            new Student { Id = 4, Name = "Priya", Age = 22, Department = "Electronics" },
            new Student { Id = 5, Name = "Arjun", Age = 19, Department = "Civil Engineering" },
            new Student { Id = 6, Name = "Fatima", Age = 23, Department = "Artificial Intelligence" }
        };

        // GET: api/student
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        // GET: api/student/3
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
    }
}