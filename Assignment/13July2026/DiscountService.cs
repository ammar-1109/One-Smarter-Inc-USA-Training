namespace CustomerStoreApp
{
    class DiscountService
    {
        public decimal CalculateDiscount(decimal totalAmount)
        {
            decimal discountPercent;

            if (totalAmount < 1000)
            {
                discountPercent = 0;
            }
            else if (totalAmount >= 1000 && totalAmount <= 4999)
            {
                discountPercent = 0.10m;
            }
            else if (totalAmount >= 5000 && totalAmount <= 9999)
            {
                discountPercent = 0.20m;
            }
            else // 10000 and above
            {
                discountPercent = 0.30m;
            }

            return totalAmount * discountPercent;
        }
    }
}
