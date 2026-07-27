using System;
using System.Collections.Generic;

namespace _13July2026
{
    class CartService
    {
        public Cart BuildCart(List<Product> products)
        {
            Cart cart = new Cart();
            bool addMore = true;

            while (addMore)
            {
                Console.Write("Enter Product ID: ");
                string productId = Console.ReadLine() ?? "";

                Product? product = FindProduct(products, productId);

                if (product == null)
                {
                    Console.WriteLine("Product not found. Try again.");
                    Console.WriteLine();
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity = InputHelper.ReadInt();

                if (quantity <= product.Stock)
                {
                    product.Stock -= quantity;
                    cart.AddItem(product.ProductName, quantity, product.Price);
                    Console.WriteLine("Added to cart.");
                }
                else
                {
                    Console.WriteLine("Insufficient stock. Only " + product.Stock + " available.");
                }

                Console.WriteLine();
                Console.WriteLine("Do you want to add another product?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine() ?? "";

                addMore = (choice == "1");
                Console.WriteLine();
            }

            return cart;
        }

        public void DisplayCart(Cart cart)
        {
            Console.WriteLine("===== CART =====");

            foreach (CartItem item in cart.GetItems())
            {
                Console.WriteLine(item.ProductName + " x" + item.Quantity);
            }

            Console.WriteLine();
        }

        private Product? FindProduct(List<Product> products, string productId)
        {
            foreach (Product p in products)
            {
                if (p.ProductId.Equals(productId, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
