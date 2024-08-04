//Profit = incoming Money - Outgoing Money
//Outgoung Parameters = cogs, expense, gstAmount
//Incoming Money parms - actual sales


namespace PolymorphismExample
{
    internal class IndianSale
    {
        public int GetTaxPercent(string item)
        {
            if(item == "IT")
            {
                return 18;
            }
            else
            {
                return 10;
            }
        }
        public double SalesNetProfit(double cogs,double expense, double actual_sales)
        {
            return actual_sales-(cogs+expense);
        }

        public double SalesNetProfit(double cogs, double expense, double actual_sales,int gstPercent)
        {
            double gstAmount = actual_sales * gstPercent / 100;
            return actual_sales - (cogs + expense+ gstAmount);
        }
    }
}
