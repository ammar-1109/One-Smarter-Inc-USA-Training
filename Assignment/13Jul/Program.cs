using System;
using System.Collections.Generic;

namespace CustomerStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistrationService registrationService = new RegistrationService();
            Customer customer = registrationService.Register();

            LoginService loginService = new LoginService();
            bool loggedIn = loginService.Login(customer);

            if (!loggedIn)
            {
                return; 
            }


            ProductService productService = new ProductService();
            List<Product> products = productService.AddProducts();
            productService.DisplayProducts(products);
            productService.SearchProduct(products);

            productService.DisplayProducts(products);
            CartService cartService = new CartService();
            Cart cart = cartService.BuildCart(products);
            cartService.DisplayCart(cart);

            DiscountService discountService = new DiscountService();
            decimal totalAmount = cart.GetTotal();
            decimal discount = discountService.CalculateDiscount(totalAmount);
            decimal finalAmount = totalAmount - discount;

            Console.WriteLine();
            Console.WriteLine("Total Amount : " + totalAmount);
            Console.WriteLine("Discount     : " + discount);
            Console.WriteLine("Final Amount : " + finalAmount);

            PaymentService paymentService = new PaymentService();
            paymentService.ProcessPayment();

            Console.WriteLine();
            Console.WriteLine("Thank you for shopping with us!");
        }
    }
}
