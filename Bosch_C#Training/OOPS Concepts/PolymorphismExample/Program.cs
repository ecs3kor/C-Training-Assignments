namespace PolymorphismExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndianSale indianSale = new IndianSale();
            Console.WriteLine(indianSale.SalesNetProfit(200, 300, 10000));
            Console.WriteLine(indianSale.SalesNetProfit(200, 300, 10000, 3));
            Console.WriteLine(indianSale.SalesNetProfit(200, 200, 10000, indianSale.GetTaxPercent("FOOD")));

            DubaiSales indianSales = new DubaiSales();
            Console.WriteLine(indianSales.SalesNetProfit(200, 300, 10000, 4,900));
        }
    }
}
