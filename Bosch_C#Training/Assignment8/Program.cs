namespace Assignment8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a year to check if its a leap year or not : Year - ");
            int year = int.Parse(Console.ReadLine());

            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                Console.WriteLine($"{year} is a leap year");
            }
            else
            {
                Console.WriteLine($"{year} is not a leap year");
            }

        }
    }
}
