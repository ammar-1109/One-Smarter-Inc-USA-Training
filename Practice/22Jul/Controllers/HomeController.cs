using _22Jul.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _22Jul.Controllers
{
    public class HomeController : Controller
    {
        //show form data
        public IActionResult Index()
        {
            return View();
        }

        //receive form data
        [HttpPost]
        public ActionResult Index(Product product)
        {
            if (ModelState.IsValid)
            {
                return Content(
                    $"Product: {product.Name}, " +
                    $"Price: {product.Price}, " +
                    $"Category: {product.Category}, " +
                    $"Stock: {product.Stock}"
                );
            }
            return View(product);
        }
    }
}
