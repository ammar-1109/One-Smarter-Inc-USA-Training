using Microsoft.AspNetCore.Mvc;
using _28July2026.Models;
using _28July2026.Services;

namespace _28July2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = _productService.UpdateProduct(id, product);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}