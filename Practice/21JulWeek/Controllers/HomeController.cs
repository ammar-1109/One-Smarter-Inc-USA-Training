using _21JulWeek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _21JulWeek.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {

            }
        }

       
    }
}
