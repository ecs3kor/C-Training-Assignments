namespace namedParameteresWithDefaultValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesCalculation salesCalculation = new SalesCalculation();
            //named parameters
            Console.WriteLine(salesCalculation.SalesNetProfitCalculation(12000,expense:10000));
        }
    }
}
