using System;

namespace _14July2026
{
    class Pen : StationeryItem
    {
        public string InkColor { get; set; } = "";
        public string PenType { get; set; } = "";

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("InkColor : " + InkColor);
            Console.WriteLine("PenType  : " + PenType);
        }

        public override decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.05m; 
        }
    }
}
