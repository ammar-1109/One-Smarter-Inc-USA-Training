using System.Collections.Generic;

namespace CustomerStoreApp
{
    class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddItem(string productName, int quantity, decimal price)
        {
            items.Add(new CartItem
            {
                ProductName = productName,
                Quantity = quantity,
                Price = price
            });
        }

        public List<CartItem> GetItems()
        {
            return items;
        }

        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (CartItem item in items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}
