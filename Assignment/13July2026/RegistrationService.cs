using System;

namespace _13July2026
{
    class RegistrationService
    {
        public Customer Register()
        {
            Console.WriteLine("===== CUSTOMER REGISTRATION =====");

            Customer customer = new Customer();

            Console.Write("Enter Customer ID: ");
            customer.CustomerId = Console.ReadLine() ?? "";

            Console.Write("Enter Name: ");
            customer.Name = Console.ReadLine() ?? "";

            Console.Write("Enter Email: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Enter Password: ");
            customer.Password = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Registration Successful");
            Console.WriteLine();

            return customer;
        }
    }
}
