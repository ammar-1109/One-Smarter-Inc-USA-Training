using System;

namespace _13July2026
{
    class LoginService
    {
        private const int MaxAttempts = 3;

        public bool Login(Customer customer)
        {
            Console.WriteLine("===== CUSTOMER LOGIN =====");

            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.Write("Enter Email: ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Enter Password: ");
                string password = Console.ReadLine() ?? "";

                if (email == customer.Email && password == customer.Password)
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome " + customer.Name);
                    Console.WriteLine();
                    return true;
                }

                attempts++;
                int remaining = MaxAttempts - attempts;

                if (remaining > 0)
                {
                    Console.WriteLine("Invalid credentials. Attempts remaining: " + remaining);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Account Locked");
            return false;
        }
    }
}
