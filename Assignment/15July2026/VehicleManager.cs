using System.Collections.Generic;
using System.Linq;

namespace _15July2026
{

    public class VehicleManager
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public IReadOnlyList<Vehicle> GetAll() => _vehicles;

        public bool Exists(int id) => FindById(id) != null;

        public Vehicle? FindById(int id)
        {
            return _vehicles.FirstOrDefault(v => v.Id == id);
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            if (Exists(vehicle.Id))
            {
                return false;
            }

            _vehicles.Add(vehicle);
            return true;
        }

        public bool UpdatePrice(int id, double newPrice)
        {
            var vehicle = FindById(id);
            if (vehicle == null)
            {
                return false;
            }

            vehicle.Price = newPrice;
            return true;
        }

        public bool DeleteVehicle(int id)
        {
            var vehicle = FindById(id);
            if (vehicle == null)
            {
                return false;
            }

            _vehicles.Remove(vehicle);
            return true;
        }

        public (double DiscountAmount, double FinalPrice)? CalculateDiscount(int id)
        {
            var vehicle = FindById(id);
            if (vehicle == null)
            {
                return null;
            }

            double discountAmount = vehicle.Price * vehicle.DiscountPercent / 100;
            double finalPrice = vehicle.Price - discountAmount;

            return (discountAmount, finalPrice);
        }
    }
}
