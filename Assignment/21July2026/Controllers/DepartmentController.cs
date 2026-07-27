using _21July2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21July2026.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Details()
        {
            if (HttpContext.Session.GetString("IsRegistered") != "true")
            {
                return RedirectToAction("Register", "Employee");
            }

            string departmentName = HttpContext.Session.GetString("Department") ?? "";
            Department? department = DepartmentData.GetDepartments()
                .FirstOrDefault(d => d.DepartmentName == departmentName);

            if (department == null)
            {
                return RedirectToAction("Register", "Employee");
            }

            return View(department);
        }
    }
}
