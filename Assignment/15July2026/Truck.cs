using System;

namespace _15July2026
{
    public class Truck : Vehicle
    {
        public override string Type => "Truck";
        public override double DiscountPercent => 12;

        public Truck(int id, string name, string brand, double price, int year)
            : base(id, name, brand, price, year)
        {
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Truck is used for transportation.");
            Console.WriteLine("Heavy load vehicle.");
            Console.WriteLine();
        }
    }
}
