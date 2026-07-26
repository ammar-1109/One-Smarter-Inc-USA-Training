using System;
using System.Collections.Generic;

namespace CustomerStoreApp
{
    class ProductService
    {
        public List<Product> AddProducts()
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("===== ADD PRODUCTS =====");
            Console.Write("How many products do you want to add? ");
            int count = InputHelper.ReadInt();

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Product " + i);

                Product product = new Product();

                Console.Write("Enter Product ID: ");
                product.ProductId = Console.ReadLine() ?? "";

                Console.Write("Enter Product Name: ");
                product.ProductName = Console.ReadLine() ?? "";

                Console.Write("Enter Price: ");
                product.Price = InputHelper.ReadDecimal();

                Console.Write("Enter Stock: ");
                product.Stock = InputHelper.ReadInt();

                products.Add(product);
            }

            Console.WriteLine();
            return products;
        }

        public void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("===== PRODUCT LIST =====");

            foreach (Product p in products)
            {
                Console.WriteLine("ID: " + p.ProductId +
                                   " | Name: " + p.ProductName +
                                   " | Price: " + p.Price +
                                   " | Stock: " + p.Stock);
            }

            Console.WriteLine();
        }

        public void SearchProduct(List<Product> products)
        {
            Console.Write("Enter product name to search: ");
            string searchName = Console.ReadLine() ?? "";

            Product? found = null;

            foreach (Product p in products)
            {
                if (p.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    found = p;
                    break;
                }
            }

            Console.WriteLine();

            if (found != null)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine();
                Console.WriteLine("Product Id   : " + found.ProductId);
                Console.WriteLine("Product Name : " + found.ProductName);
                Console.WriteLine("Price        : " + found.Price);
                Console.WriteLine("Stock        : " + found.Stock);
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }

            Console.WriteLine();
        }
    }
}
