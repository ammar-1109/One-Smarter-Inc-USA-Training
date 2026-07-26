using System;

namespace CustomerStoreApp
{
    static class InputHelper
    {
        public static int ReadInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Please enter a valid whole number: ");
            }
            return value;
        }

        public static decimal ReadDecimal()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Please enter a valid number: ");
            }
            return value;
        }
    }
}
