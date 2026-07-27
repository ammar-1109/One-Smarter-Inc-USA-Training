using _21July2026.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _21July2026.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Register()
        {
            ViewBag.Departments = new SelectList(DepartmentData.GetDepartments(), "DepartmentName", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("IsRegistered", "true");
                HttpContext.Session.SetString("EmployeeName", employee.EmployeeName);
                HttpContext.Session.SetString("Department", employee.Department);
                return RedirectToAction("Success");
            }

            ViewBag.Departments = new SelectList(DepartmentData.GetDepartments(), "DepartmentName", "DepartmentName");
            return View(employee);
        }

        public IActionResult Success()
        {
            if (HttpContext.Session.GetString("IsRegistered") != "true")
            {
                return RedirectToAction("Register");
            }

            ViewBag.EmployeeName = HttpContext.Session.GetString("EmployeeName");
            ViewBag.Department = HttpContext.Session.GetString("Department");
            return View();
        }
    }
}
