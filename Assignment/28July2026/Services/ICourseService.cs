using _28July2026.Models;

namespace _28July2026.Services
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course? GetById(int id);
        Course? RegisterCourse(Course course);
        Course? UpdateDuration(int id ,Course course);
        bool CancelCourse(int id);
    }
}
