namespace PolymorphismExample
{
    internal class DubaiSales: IndianSale
    {
        public double SalesNetProfit(double cogs, double expense, double actualSales, int gstPercent, double transportCost)
        {
            double gstAmount = actualSales * gstPercent / 100;
            return actualSales - (cogs + expense + gstAmount + transportCost);
        }
    }
}
