using System;

namespace _14July2026
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
