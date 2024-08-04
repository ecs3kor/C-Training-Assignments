using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Assignment10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string entry;
            Console.WriteLine("Enter which operation has to be performed");
            Console.WriteLine("Type add for Addition");
            Console.WriteLine("Type sub for Subtraction");
            Console.WriteLine("Type mul for multiplication");
            Console.WriteLine("Type div for Division");
            entry = Console.ReadLine();


            Console.WriteLine("Enter the numbers to be operated");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (entry)
            {
                case "add":
                    int sum = a + b;
                    Console.WriteLine("Result: " + sum);
                    break;
                case "sub":
                    int diff = a - b;
                    Console.WriteLine("Result: " + diff);
                    break;
                case "mul":
                    int prod = a * b;
                    Console.WriteLine("Result: " + prod);
                    break;
                case "div":
                    if (b != 0)
                    {
                        int quo = a / b;
                        Console.WriteLine("Result: " + quo);
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;

            }
        }
    }
}
