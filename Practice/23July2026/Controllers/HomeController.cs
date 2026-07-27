using _23July2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23July2026.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (username == "admin" && password == "12345")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Message = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}