using System;

namespace StationeryStoreApp
{

    abstract class StationeryItem : Product
    {
        private string itemId = "";
        private string itemName = "";
        private string category = "";
        private string brand = "";
        private decimal price;
        private int quantity;

        public string ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidPriceException();
                }
                price = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidQuantityException();
                }
                quantity = value;
            }
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("ID       : " + ItemId);
            Console.WriteLine("Name     : " + ItemName);
            Console.WriteLine("Category : " + Category);
            Console.WriteLine("Brand    : " + Brand);
            Console.WriteLine("Price    : " + Price);
            Console.WriteLine("Quantity : " + Quantity);
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public void ReduceStock(int purchasedQuantity)
        {
            quantity -= purchasedQuantity;
        }
    }
}
