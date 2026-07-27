using System;

namespace ABCMotors
{
    public class Bike : Vehicle
    {
        public override string Type => "Bike";
        public override double DiscountPercent => 5;

        public Bike(int id, string name, string brand, double price, int year)
            : base(id, name, brand, price, year)
        {
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Bike is fuel efficient.");
            Console.WriteLine("Suitable for city rides.");
            Console.WriteLine();
        }
    }
}
