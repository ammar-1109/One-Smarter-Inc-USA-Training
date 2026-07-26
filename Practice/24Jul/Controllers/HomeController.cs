using _24Jul.Models;
using Microsoft.AspNetCore.Mvc;

namespace _24Jul.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login Page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.username == "admin" && student.password == "12345")
                {
                    HttpContext.Session.SetString("User", student.username);
                    return RedirectToAction("Dashboard");
                }

                ViewBag.Error = "Invalid Username or Password";
            }

            return View(student);
        }

        // Dashboard
        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index");
            }

            ViewBag.User = user;

            List<Schedule> schedules = new List<Schedule>()
    {
        new Schedule
        {
            ScheduleID = 1,
            Subject = "Mathematics",
            Faculty = "Dr. Sharma",
            Day = "Monday",
            StartTime = "09:00 AM",
            EndTime = "10:00 AM",
            RoomNo = "A-101"
        },
        new Schedule
        {
            ScheduleID = 2,
            Subject = "Data Structures",
            Faculty = "Prof. Patil",
            Day = "Tuesday",
            StartTime = "10:00 AM",
            EndTime = "11:00 AM",
            RoomNo = "B-203"
        },
        new Schedule
        {
            ScheduleID = 3,
            Subject = "Operating Systems",
            Faculty = "Dr. Khan",
            Day = "Wednesday",
            StartTime = "11:30 AM",
            EndTime = "12:30 PM",
            RoomNo = "C-105"
        },
        new Schedule
        {
            ScheduleID = 4,
            Subject = "Database Management",
            Faculty = "Prof. Joshi",
            Day = "Thursday",
            StartTime = "01:00 PM",
            EndTime = "02:00 PM",
            RoomNo = "A-205"
        },
        new Schedule
        {
            ScheduleID = 5,
            Subject = "Computer Networks",
            Faculty = "Dr. Deshmukh",
            Day = "Friday",
            StartTime = "02:30 PM",
            EndTime = "03:30 PM",
            RoomNo = "Lab-2"
        }
    };

            return View(schedules);
        }
        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}