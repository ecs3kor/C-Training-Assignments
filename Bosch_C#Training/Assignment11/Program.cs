namespace Assignment11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a ,b ,c;
            Console.WriteLine("Enter 3 numbers to be found the max");
            Console.WriteLine("a=");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("b=");
            b=int.Parse(Console.ReadLine());
            Console.WriteLine("c=");
            c=int.Parse(Console.ReadLine());

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine($"a = {a} is max");
                }
                else if (b > c)
                {
                    Console.WriteLine($"b= {b} is max");
                }
            }
            else
            {
                Console.WriteLine($"c = {c} is max");
            }
        }
    }
}
