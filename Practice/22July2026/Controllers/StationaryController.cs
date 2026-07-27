using _22July2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22July2026.Controllers
{
    public class StationaryController : Controller
    {
        //show form data
        public IActionResult Stationary()
        {
            return View();
        }

        //receive form data
        [HttpPost]
        public ActionResult Stationary(Stationary stationary)
        {
            if (ModelState.IsValid)
            {
                return Content(
                    $"Item Name: {stationary.ItemName}\n" +
                    $"Brand: {stationary.Brand}\n" +
                    $"Price: {stationary.Price}\n" +
                    $"Quantity: {stationary.Quantity}\n" +
                    $"Category: {stationary.Category}"
                );
            }

            return View(stationary);
        }
    }
}
