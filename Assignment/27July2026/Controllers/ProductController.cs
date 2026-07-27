using Microsoft.AspNetCore.Mvc;
using _27July2026.Models;

namespace _27July2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Pen",
                Price = 20,
                Stock = 50
            },
            new Product()
            {
                Id = 2,
                Name = "Book",
                Price = 40,
                Stock = 30
            }
        };

        // GET : api/Product
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(products);
        }

        // GET : api/Product/1
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        // POST : api/Product
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            products.Add(product);
            return Ok(product);
        }

        // PUT : api/Product/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product prod)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Usually don't update the ID
            product.Name = prod.Name;
            product.Price = prod.Price;
            product.Stock = prod.Stock;

            return Ok(product);
        }

        // DELETE : api/Product/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            products.Remove(product);
            return Ok("Product deleted successfully");
        }
    }
}