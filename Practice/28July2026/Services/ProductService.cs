using _28July2026.Models;

namespace _28July2026.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Charger",    Price = 500,   Quantity = 10 },
            new Product { Id = 2, Name = "Mouse",      Price = 700,   Quantity = 25 },
            new Product { Id = 3, Name = "Keyboard",   Price = 1200,  Quantity = 15 },
            new Product { Id = 4, Name = "Headphones", Price = 2500,  Quantity = 8 },
            new Product { Id = 5, Name = "USB Cable",  Price = 300,   Quantity = 30 }
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product? GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public Product? UpdateProduct(int id, Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;

            return existing;
        }

        public bool DeleteProduct(int id)
        {
            var existing = products.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return false;
            }
            products.Remove(existing);
            return true;
        }
    }
}