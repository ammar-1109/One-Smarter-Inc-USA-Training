using System;

namespace StationeryStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginService loginService = new LoginService();

            try
            {
                loginService.Login();
            }
            catch (LoginFailedException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting application.");
            }

            StationeryService stationeryService = new StationeryService();
            PurchaseService purchaseService = new PurchaseService();
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Stationery Store Management System");
                Console.WriteLine("------------------------------------");
                Console.WriteLine();
                Console.WriteLine("1. Add Stationery Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Search Item");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Purchase Item");
                Console.WriteLine("7. View Low Stock Items");
                Console.WriteLine("8. Sort Items");
                Console.WriteLine("9. Exit");
                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine() ?? "";


                try
                {
                    switch (choice)
                    {
                        case "1":
                            stationeryService.AddItem();
                            break;
                        case "2":
                            stationeryService.DisplayItems();
                            break;
                        case "3":
                            stationeryService.SearchItem();
                            break;
                        case "4":
                            stationeryService.UpdateItem();
                            break;
                        case "5":
                            stationeryService.DeleteItem();
                            break;
                        case "6":
                            purchaseService.Purchase(stationeryService);
                            break;
                        case "7":
                            stationeryService.ShowLowStockItems();
                            break;
                        case "8":
                            stationeryService.SortItems();
                            break;
                        case "9":
                            running = false;
                            Console.WriteLine();
                            Console.WriteLine("Thank You");
                            Console.WriteLine("Visit Again");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (InvalidPriceException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (InvalidQuantityException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (DuplicateItemException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (ItemNotFoundException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (InsufficientStockException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (Exception ex) { Console.WriteLine("Unexpected error: " + ex.Message); }
            }
        }
    }
}
