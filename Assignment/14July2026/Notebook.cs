using System;

namespace StationeryStoreApp
{
    class Notebook : StationeryItem
    {
        public int Pages { get; set; }
        public string PaperType { get; set; } = "";


        public override void DisplayDetails()
        {
            base.DisplayDetails(); 
            Console.WriteLine("Pages    : " + Pages);
            Console.WriteLine("PaperType: " + PaperType);
        }

        public override decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.10m; 
        }
    }
}
