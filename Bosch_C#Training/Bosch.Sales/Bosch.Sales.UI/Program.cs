using Bosch.Sales.Calculation;

namespace Bosch.Sales.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesBase s = new SalesBase();
            Console.WriteLine(s.SalesNetProfit(12000,12000,120000));
            Console.WriteLine(s.SalesNetProfit(12000,12000,120000,18));
        }
    }
}
