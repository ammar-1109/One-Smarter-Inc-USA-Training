using _28July2026.Models;

namespace _28July2026.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product AddProduct(Product product);
        Product? UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
    }
}