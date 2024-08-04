namespace namedParameteresWithDefaultValues
{
    //Default or optional parameters should be at the end of the parameter list
    internal class SalesCalculation
    {
        public double SalesNetProfitCalculation(double cogs,double expense=14000,double actual_sales=90000,int gstPercent=18)
        {
            double gstAmount = actual_sales * gstPercent / 100;
            return actual_sales - (cogs + expense + gstAmount); ;
        }
    }
}
