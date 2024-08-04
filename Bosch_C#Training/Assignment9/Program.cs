namespace Assignment9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the Basic Salary and Total Sales amount of the Employee:");
            Console.WriteLine("Basic Salary: Rupees ");
            double basicSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Total Sales amount: Rupees ");
            double totalSales = double.Parse(Console.ReadLine());
            double netSalary=0, commission=0;
            if (totalSales >= 5000 && totalSales <= 7500)
            {
                commission = totalSales * 0.03;
            }else if(totalSales >=7501 &&  totalSales <= 10500)
            {
                commission = (totalSales * 0.08);
            }else if(totalSales >=10501 && totalSales <= 15000)
            {
                commission = totalSales * 0.11;
            }
            else
            {
                commission = totalSales * 0.15;
            }

            netSalary = basicSalary + commission;
            Console.WriteLine($"Commission earned is: {commission}");
            Console.WriteLine($"NetSalary is :{netSalary}");
        }
    }
}
