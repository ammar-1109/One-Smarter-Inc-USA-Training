using System;

namespace StationeryStoreApp
{
    class Marker : StationeryItem
    {
        public bool Permanent { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Permanent: " + Permanent);
        }

        public override decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.08m; 
        }
    }
}
