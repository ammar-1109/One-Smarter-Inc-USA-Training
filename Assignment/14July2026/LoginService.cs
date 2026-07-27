using System;

namespace _14July2026
{
    class LoginService
    {
        private const string ValidUsername = "admin";
        private const string ValidPassword = "admin123";
        private const int MaxAttempts = 3;

        public bool Login()
        {
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine() ?? "";

                Console.Write("Enter Password: ");
                string password = Console.ReadLine() ?? "";

                if (username == ValidUsername && password == ValidPassword)
                {
                    return true;
                }

                attempts++;
                int attemptsLeft = MaxAttempts - attempts;

                Console.WriteLine();
                Console.WriteLine("Invalid Login");

                if (attemptsLeft > 0)
                {
                    Console.WriteLine("Attempts Left : " + attemptsLeft);
                    Console.WriteLine();
                }
            }

            throw new LoginFailedException();
        }
    }
}
