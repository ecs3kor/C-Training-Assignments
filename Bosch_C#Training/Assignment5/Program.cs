namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m, temp;
            Console.WriteLine("Enter n :");
            n=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter m :");
            m=int.Parse(Console.ReadLine());
            Console.WriteLine($"Initially n={n} and m={m}");
            temp = m;
            m = n;
            n=temp;
            Console.WriteLine($"After swapping n={n} and m={m}");
           
        }
    }
}
