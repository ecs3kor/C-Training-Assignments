using System.Data;

namespace Assignment12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dept="", designation="";
            Console.WriteLine("Enter employee number");
            int empNo=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department Number in [10,20,30,40,50]");
            int deptNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Designation code in ['M','S','a','s','A']");
            char desgn_code=char.Parse(Console.ReadLine());
            Dictionary<int, string> dic = new Dictionary<int, string>
                {
                    { 10, "Purchase" },
                    { 20, "Sales" },
                    { 30, "Production" },
                    { 40, "Marketing" },
                    { 50, "Accounts" }
                };

            Dictionary<char, string> desgnDict = new Dictionary<char, string>
            {
                { 'M', "Manager" },
                { 'S', "Supervisor" },
                { 'A', "Analyst" },
                { 's', "SalesPerson" },
                { 'a', "Accountant" }
            };

            Console.WriteLine($"Employee {empNo} works for {dic[deptNo]} and has designation {desgnDict[desgn_code]}");


        }
    }
}
