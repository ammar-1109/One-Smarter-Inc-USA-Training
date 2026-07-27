using _22July2026.Models;
using _22July2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace _22July2026.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: Show manufacturer form (only if automobile is registered)
        [HttpGet]
        public IActionResult Index()
        {
            if (!IsAutomobileRegistered())
            {
                ViewBag.BlockAccess = true;
                return View(new Manufacturer());
            }

            return View(new Manufacturer());
        }

        // GET: Display all manufacturer entries
        [HttpGet]
        public IActionResult List()
        {
            if (!IsAutomobileRegistered())
            {
                ViewBag.BlockAccess = true;
                return View(new List<Manufacturer>());
            }

            return View(DataStore.Manufacturers);
        }

        // POST: Accept manufacturer details using Model Binding
        [HttpPost]
        public IActionResult Index(Manufacturer manufacturer)
        {
            if (!IsAutomobileRegistered())
            {
                ViewBag.BlockAccess = true;
                return View(manufacturer);
            }

            if (ModelState.IsValid)
            {
                DataStore.Manufacturers.Add(manufacturer);
                ViewBag.ShowDetails = true;
                return View(manufacturer);
            }

            return View(manufacturer);
        }

        private bool IsAutomobileRegistered()
        {
            return HttpContext.Session.GetString("AutomobileRegistered") == "true";
        }
    }
}
