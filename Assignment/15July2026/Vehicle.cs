using System;

namespace _15July2026
{
  
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public abstract string Type { get; }

        public abstract double DiscountPercent { get; }

        protected Vehicle(int id, string name, string brand, double price, int year)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
            Year = year;
        }

        public abstract void ShowDetails();

        public void PrintSummary()
        {
            Console.WriteLine("Vehicle ID        : " + Id);
            Console.WriteLine("Vehicle Name       : " + Name);
            Console.WriteLine("Vehicle Type       : " + Type);
            Console.WriteLine("Brand              : " + Brand);
            Console.WriteLine("Price              : " + Price);
            Console.WriteLine("Manufacturing Year : " + Year);
            Console.WriteLine();
        }
    }
}
