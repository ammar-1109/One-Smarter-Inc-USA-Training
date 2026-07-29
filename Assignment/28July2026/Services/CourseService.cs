using _28July2026.Models;

namespace _28July2026.Services
{
    public class CourseService : ICourseService
    {
        static List<Course> courses = new List<Course>()
        {
            new Course { Id = 1, Title = "Computer Programming", Credits = 4, Duration = 12 },
            new Course { Id = 2, Title = "Data Structures", Credits = 4, Duration = 14 },
            new Course { Id = 3, Title = "Database Management Systems", Credits = 3, Duration = 10 },
            new Course { Id = 4, Title = "Operating Systems", Credits = 4, Duration = 15 },
            new Course { Id = 5, Title = "Web Development", Credits = 3, Duration = 8 }
        };

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course? GetById(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public Course? RegisterCourse(Course course)
        {
            if (course.Id <= 0 || courses.Any(c => c.Id == course.Id))
            {
                course.Id = courses.Any() ? courses.Max(c => c.Id) + 1 : 1;
            }
            courses.Add(course);
            return course;
        }

        public Course? UpdateDuration(int id, Course course)
        {
            var temp = courses.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                return null;
            }

            temp.Duration = course.Duration;

            return temp;
        }

        public bool CancelCourse(int id)
        {
            var temp = courses.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                return false;
            }

            courses.Remove(temp);
            return true;
        }
    }
}
