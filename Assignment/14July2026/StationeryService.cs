using System;
using System.Collections.Generic;
using System.Linq;

namespace _14July2026
{

    class StationeryService
    {
        private List<StationeryItem> items = new List<StationeryItem>();

        
        public void AddItem()
        {
            Console.WriteLine();
            Console.WriteLine("Select Item Type");
            Console.WriteLine("1. Notebook");
            Console.WriteLine("2. Pen");
            Console.WriteLine("3. Marker");
            Console.Write("Enter Choice: ");
            string typeChoice = Console.ReadLine() ?? "";

            Console.Write("Enter Item Id: ");
            string itemId = Console.ReadLine() ?? "";

            if (FindById(itemId) != null)
            {
                throw new DuplicateItemException();
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter Category: ");
            string category = Console.ReadLine() ?? "";

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine() ?? "";

            Console.Write("Enter Price: ");
            decimal price = InputHelper.ReadDecimal();

            Console.Write("Enter Quantity: ");
            int quantity = InputHelper.ReadInt();

            StationeryItem newItem;

            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter Pages: ");
                    int pages = InputHelper.ReadInt();
                    Console.Write("Enter Paper Type: ");
                    string paperType = Console.ReadLine() ?? "";
                    newItem = new Notebook { Pages = pages, PaperType = paperType };
                    break;

                case "2":
                    Console.Write("Enter Ink Color: ");
                    string inkColor = Console.ReadLine() ?? "";
                    Console.Write("Enter Pen Type: ");
                    string penType = Console.ReadLine() ?? "";
                    newItem = new Pen { InkColor = inkColor, PenType = penType };
                    break;

                case "3":
                    Console.Write("Is it Permanent (true/false): ");
                    bool permanent = bool.Parse(Console.ReadLine() ?? "false");
                    newItem = new Marker { Permanent = permanent };
                    break;

                default:
                    Console.WriteLine("Invalid type. Item not added.");
                    return;
            }

            
            newItem.ItemId = itemId;
            newItem.ItemName = name;
            newItem.Category = category;
            newItem.Brand = brand;
            newItem.Price = price;
            newItem.Quantity = quantity;

            items.Add(newItem);

            Console.WriteLine();
            Console.WriteLine("Item Added Successfully!");
        }

        
        public void DisplayItems()
        {
            Console.WriteLine();
            Console.WriteLine("===== ALL ITEMS =====");

            if (items.Count == 0)
            {
                Console.WriteLine("No items to display.");
                return;
            }

            foreach (StationeryItem item in items)
            {
                Console.WriteLine("--------------------------------");
               
                item.DisplayDetails();
            }
            Console.WriteLine("--------------------------------");
        }

       
        public void SearchItem()
        {
            Console.WriteLine();
            Console.WriteLine("Search By");
            Console.WriteLine("1. Item Id");
            Console.WriteLine("2. Item Name");
            Console.Write("Enter Choice: ");
            string choice = Console.ReadLine() ?? "";

            StationeryItem? found = null;

            if (choice == "1")
            {
                Console.Write("Enter Item Id: ");
                string id = Console.ReadLine() ?? "";
                found = FindById(id);
            }
            else if (choice == "2")
            {
                Console.Write("Enter Item Name: ");
                string name = Console.ReadLine() ?? "";
                found = FindByName(name);
            }

            if (found == null)
            {
                throw new ItemNotFoundException();
            }

            Console.WriteLine();
            Console.WriteLine("Item Found");
            Console.WriteLine("--------------------------------");
            found.DisplayDetails();
        }

        
        public void UpdateItem()
        {
            Console.Write("Enter Item Id to update: ");
            string id = Console.ReadLine() ?? "";

            StationeryItem? item = FindById(id);
            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1. Price");
            Console.WriteLine("2. Quantity");
            Console.WriteLine("3. Brand");
            Console.Write("Enter Choice: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write("Enter New Price: ");
                    item.Price = InputHelper.ReadDecimal(); 
                    break;
                case "2":
                    Console.Write("Enter New Quantity: ");
                    item.UpdateQuantity(InputHelper.ReadInt()); 
                    break;
                case "3":
                    Console.Write("Enter New Brand: ");
                    item.Brand = Console.ReadLine() ?? "";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Item Updated Successfully!");
        }

        
        public void DeleteItem()
        {
            Console.Write("Enter Item Id to delete: ");
            string id = Console.ReadLine() ?? "";

            StationeryItem? item = FindById(id);
            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.Write("Delete ? (Y/N): ");
            string confirm = Console.ReadLine() ?? "";

            if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                items.Remove(item);
                Console.WriteLine("Item Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Delete cancelled.");
            }
        }

        
        public void ShowLowStockItems()
        {
            Console.WriteLine();
            Console.WriteLine("===== LOW STOCK ITEMS (Quantity < 5) =====");

            List<StationeryItem> lowStock = items.Where(i => i.Quantity < 5).ToList();

            if (lowStock.Count == 0)
            {
                Console.WriteLine("No low stock items.");
                return;
            }

            foreach (StationeryItem item in lowStock)
            {
                Console.WriteLine("--------------------------------");
                item.DisplayDetails();
            }
            Console.WriteLine("--------------------------------");
        }

               public void SortItems()
        {
            Console.WriteLine();
            Console.WriteLine("Sort By");
            Console.WriteLine("1. Price");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Quantity");
            Console.Write("Enter Choice: ");
            string sortChoice = Console.ReadLine() ?? "";

            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            Console.Write("Enter Choice: ");
            string orderChoice = Console.ReadLine() ?? "";
            bool descending = (orderChoice == "2");

            switch (sortChoice)
            {
                case "1": 
                    items = descending
                        ? items.OrderByDescending(i => i.Price).ToList()
                        : items.OrderBy(i => i.Price).ToList();
                    break;

                case "2":
                    items.Sort((a, b) => descending
                        ? string.Compare(b.ItemName, a.ItemName)
                        : string.Compare(a.ItemName, b.ItemName));
                    break;

                case "3": 
                    items = descending
                        ? items.OrderByDescending(i => i.Quantity).ToList()
                        : items.OrderBy(i => i.Quantity).ToList();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Items sorted successfully!");
            DisplayItems();
        }

        public StationeryItem? FindById(string id)
        {
            foreach (StationeryItem item in items)
            {
                if (item.ItemId.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        private StationeryItem? FindByName(string name)
        {
            foreach (StationeryItem item in items)
            {
                if (item.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        public List<StationeryItem> GetItems()
        {
            return items;
        }
    }
}
