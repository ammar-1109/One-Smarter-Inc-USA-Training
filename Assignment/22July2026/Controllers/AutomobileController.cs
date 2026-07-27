using _22July2026.Models;
using _22July2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace _22July2026.Controllers
{
    public class AutomobileController : Controller
    {
        // GET: Display automobile registration form
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Automobile());
        }

        // GET: Display all registered automobiles
        [HttpGet]
        public IActionResult List()
        {
            return View(DataStore.Automobiles);
        }

        // POST: Accept automobile details using Model Binding
        [HttpPost]
        public IActionResult Register(Automobile automobile)
        {
            // Validate submitted data using ModelState.IsValid
            if (ModelState.IsValid)
            {
                DataStore.Automobiles.Add(automobile);

                // Store success in session so Manufacturer module can be accessed
                HttpContext.Session.SetString("AutomobileRegistered", "true");
                HttpContext.Session.SetString("VehicleName", automobile.VehicleName);
                HttpContext.Session.SetString("Brand", automobile.Brand);

                ViewBag.IsSuccess = true;
                return View(automobile);
            }

            // Return same view with validation messages
            return View(automobile);
        }
    }
}
