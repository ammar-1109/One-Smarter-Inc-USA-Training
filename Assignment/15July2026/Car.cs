using System;

namespace _15July2026
{
    public class Car : Vehicle
    {
        public override string Type => "Car";
        public override double DiscountPercent => 10;

        public Car(int id, string name, string brand, double price, int year)
            : base(id, name, brand, price, year)
        {
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Car is a four wheeler.");
            Console.WriteLine("Suitable for family.");
            Console.WriteLine();
        }
    }
}
