using System;

namespace CustomerStoreApp
{
    class PaymentService
    {
        public void ProcessPayment()
        {
            Console.WriteLine();
            Console.WriteLine("Choose Payment");
            Console.WriteLine("1. UPI");
            Console.WriteLine("2. Credit Card");
            Console.WriteLine("3. Debit Card");
            Console.WriteLine("4. Cash on Delivery");
            Console.Write("Enter choice: ");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    Console.WriteLine("Payment Successful");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}
