namespace Assignment7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Basic Salary of Employee: Rupees");
            Double basicSalary = double.Parse(Console.ReadLine());
            double HRA = basicSalary * 0.2;
            double DA = basicSalary * 0.4;
            double grossSalary = basicSalary + HRA + DA;
            double PF = grossSalary * 0.1;
            double netSalary = grossSalary - PF;
            Console.WriteLine($"The net Salary of Employee is :Rupees{ netSalary}");
        }
    }
}
