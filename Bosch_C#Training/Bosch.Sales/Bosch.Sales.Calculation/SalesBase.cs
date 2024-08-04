namespace Bosch.Sales.Calculation
{
    public class SalesBase
    {
        public double SalesNetProfit(double cogs, double expense, double actualSales)
        {
            return actualSales-(cogs+expense);
        }
        public double SalesNetProfit(double cogs, double expense, double actualSales, int gstPercent)
        {
            double gstAmount = actualSales * gstPercent / 100;
            return actualSales - (cogs + expense + gstAmount); 
        }

    }
}
