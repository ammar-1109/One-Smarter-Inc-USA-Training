using System;

namespace _15July2026
{

    public class Program
    {
        private static readonly VehicleManager Manager = new VehicleManager();

        public static void Main(string[] args)
        {
            Employee employee = Login();
            MainMenu();
        }

        // ---------------- 1. Employee Login ----------------
        private static Employee Login()
        {
            Console.Write("Enter Employee Name: ");
            string name = ConsoleHelper.ReadLineOrEmpty();

            Console.Write("Enter Employee ID: ");
            string id = ConsoleHelper.ReadLineOrEmpty();

            Console.WriteLine();
            Console.WriteLine("Welcome " + name);
            Console.WriteLine();

            return new Employee(name, id);
        }

        // ---------------- 2. Main Menu ----------------
        private static void MainMenu()
        {
            int choice = -1;

            while (choice != 8)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("ABC MOTORS");
                Console.WriteLine("Vehicle Management System");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. View All Vehicles");
                Console.WriteLine("3. Search Vehicle");
                Console.WriteLine("4. Update Vehicle Price");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. Calculate Discount");
                Console.WriteLine("7. Show Vehicle Details");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                choice = ConsoleHelper.ReadInt();

                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        DisplayVehicles();
                        break;
                    case 3:
                        SearchVehicle();
                        break;
                    case 4:
                        UpdateVehiclePrice();
                        break;
                    case 5:
                        DeleteVehicle();
                        break;
                    case 6:
                        CalculateDiscount();
                        break;
                    case 7:
                        ShowVehicleDetails();
                        break;
                    case 8:
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using ABC Motors System.");
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice! Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        // ---------------- 3. Add Vehicle ----------------
        private static void AddVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("--- Add New Vehicle ---");

            Console.Write("Vehicle ID: ");
            int id = ConsoleHelper.ReadInt();

            if (Manager.Exists(id))
            {
                Console.WriteLine("Vehicle ID already exists!");
                Console.WriteLine();
                return;
            }

            Console.Write("Vehicle Name: ");
            string name = ConsoleHelper.ReadLineOrEmpty();

            Console.Write("Vehicle Type (Car/Bike/Truck): ");
            string type = ConsoleHelper.ReadLineOrEmpty();

            Console.Write("Brand: ");
            string brand = ConsoleHelper.ReadLineOrEmpty();

            Console.Write("Price: ");
            double price = ConsoleHelper.ReadDouble();

            Console.Write("Manufacturing Year: ");
            int year = ConsoleHelper.ReadInt();

            Vehicle? vehicle = VehicleFactory.Create(id, name, type, brand, price, year);

            if (vehicle == null)
            {
                Console.WriteLine("Invalid vehicle type. Vehicle not added.");
                Console.WriteLine();
                return;
            }

            Manager.AddVehicle(vehicle);
            Console.WriteLine("Vehicle added successfully!");
            Console.WriteLine();
        }

        // ---------------- 4. Display All Vehicles ----------------
        private static void DisplayVehicles()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("{0,-5}{1,-10}{2,-10}{3,-10}{4,-10}", "ID", "Name", "Brand", "Type", "Price");
            Console.WriteLine("-------------------------------------------------------------");

            var vehicles = Manager.GetAll();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available.");
            }
            else
            {
                foreach (var v in vehicles)
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-10}{3,-10}{4,-10:F2}",
                        v.Id, v.Name, v.Brand, v.Type, v.Price);
                }
            }
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
        }

        // ---------------- 5. Search Vehicle ----------------
        private static void SearchVehicle()
        {
            Console.WriteLine();
            Console.Write("Enter Vehicle ID: ");
            int id = ConsoleHelper.ReadInt();

            var vehicle = Manager.FindById(id);

            Console.WriteLine();
            if (vehicle != null)
            {
                Console.WriteLine("Vehicle Found:");
                vehicle.PrintSummary();
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
                Console.WriteLine();
            }
        }

        // ---------------- 6. Update Vehicle Price ----------------
        private static void UpdateVehiclePrice()
        {
            Console.WriteLine();
            Console.Write("Enter Vehicle ID: ");
            int id = ConsoleHelper.ReadInt();

            var vehicle = Manager.FindById(id);
            if (vehicle == null)
            {
                Console.WriteLine("Vehicle ID does not exist.");
                Console.WriteLine();
                return;
            }

            Console.Write("Enter New Price: ");
            double newPrice = ConsoleHelper.ReadDouble();

            Manager.UpdatePrice(id, newPrice);
            Console.WriteLine("Price updated successfully!");
            Console.WriteLine();
        }

        // ---------------- 7. Delete Vehicle ----------------
        private static void DeleteVehicle()
        {
            Console.WriteLine();
            Console.Write("Enter Vehicle ID: ");
            int id = ConsoleHelper.ReadInt();

            bool deleted = Manager.DeleteVehicle(id);

            Console.WriteLine(deleted ? "Vehicle deleted successfully!" : "Vehicle not available.");
            Console.WriteLine();
        }

        // ---------------- 8. Calculate Discount ----------------
        private static void CalculateDiscount()
        {
            Console.WriteLine();
            Console.Write("Enter Vehicle ID: ");
            int id = ConsoleHelper.ReadInt();

            var vehicle = Manager.FindById(id);
            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found.");
                Console.WriteLine();
                return;
            }

            var result = Manager.CalculateDiscount(id);
            if (result == null)
            {
                Console.WriteLine("Vehicle not found.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Vehicle Price : " + vehicle.Price);
            Console.WriteLine("Discount (" + (int)vehicle.DiscountPercent + "%) : " + result.Value.DiscountAmount);
            Console.WriteLine("Final Price : " + result.Value.FinalPrice);
            Console.WriteLine();
        }

        // ---------------- 9. Show Vehicle Details (by type) ----------------
        private static void ShowVehicleDetails()
        {
            Console.WriteLine();
            Console.Write("Enter Vehicle Type (Car/Bike/Truck): ");
            string type = ConsoleHelper.ReadLineOrEmpty();

            switch (type.Trim().ToLower())
            {
                case "car":
                    new Car(0, "", "", 0, 0).ShowDetails();
                    break;
                case "bike":
                    new Bike(0, "", "", 0, 0).ShowDetails();
                    break;
                case "truck":
                    new Truck(0, "", "", 0, 0).ShowDetails();
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
