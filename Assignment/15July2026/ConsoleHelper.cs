using System;
using System.Globalization;

namespace ABCMotors
{

    public static class ConsoleHelper
    {
        public static int ReadInt()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input?.Trim(), out int value))
                {
                    return value;
                }
                Console.Write("Please enter a valid number: ");
            }
        }

        public static double ReadDouble()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input?.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                {
                    return value;
                }
                Console.Write("Please enter a valid number: ");
            }
        }

        public static string ReadLineOrEmpty()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
