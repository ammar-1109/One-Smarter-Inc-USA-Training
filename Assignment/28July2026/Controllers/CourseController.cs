using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _28July2026.Models;
using _28July2026.Services;

namespace _28July2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Course>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = _service.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> RegisterCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cour = _service.RegisterCourse(course);
            return CreatedAtAction(nameof(GetById), new { id = cour?.Id }, cour);
        }

        [HttpPut("{id}")]
        public ActionResult<Course> UpdateDuration(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cour = _service.UpdateDuration(id, course);
            if (cour == null)
            {
                return NotFound();
            }
            return Ok(cour);
        }

        [HttpDelete("{id}")]
        public IActionResult CancelCourse(int id)
        {
            var deleted = _service.CancelCourse(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
