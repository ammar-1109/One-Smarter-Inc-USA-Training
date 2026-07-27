using System;

namespace _15July2026
{

    public static class VehicleFactory
    {
        public static Vehicle? Create(int id, string name, string type, string brand, double price, int year)
        {
            switch (type.Trim().ToLower())
            {
                case "car":
                    return new Car(id, name, brand, price, year);
                case "bike":
                    return new Bike(id, name, brand, price, year);
                case "truck":
                    return new Truck(id, name, brand, price, year);
                default:
                    return null;
            }
        }
    }
}
