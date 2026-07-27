using System;

namespace StationeryStoreApp
{

    class PurchaseService : IBill
    {
        private const decimal GstRate = 0.05m; 

        private StationeryItem? lastItem;
        private int lastQuantity;
        private decimal lastSubtotal;
        private decimal lastDiscount;
        private decimal lastGst;
        private decimal lastTotal;

        public void Purchase(StationeryService service)
        {
            Console.Write("Enter Item Id: ");
            string id = Console.ReadLine() ?? "";

            StationeryItem? item = service.FindById(id);
            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.Write("Enter Quantity: ");
            int quantity = InputHelper.ReadInt();

            if (quantity > item.Quantity)
            {
                throw new InsufficientStockException();
            }

            item.ReduceStock(quantity);

            decimal subtotal = item.Price * quantity;
            decimal discount = item.CalculateDiscount(subtotal); 
            decimal afterDiscount = subtotal - discount;
            decimal gst = afterDiscount * GstRate;
            decimal total = afterDiscount + gst;

            lastItem = item;
            lastQuantity = quantity;
            lastSubtotal = subtotal;
            lastDiscount = discount;
            lastGst = gst;
            lastTotal = total;

            GenerateBill();
        }

        public void GenerateBill()
        {
            if (lastItem == null)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Item      : " + lastItem.ItemName);
            Console.WriteLine("Price     : " + lastItem.Price);
            Console.WriteLine("Quantity  : " + lastQuantity);
            Console.WriteLine("Discount  : " + lastDiscount);
            Console.WriteLine("GST       : " + lastGst);
            Console.WriteLine("Total     : " + lastTotal);
            Console.WriteLine("--------------------------------");
        }
    }
}
