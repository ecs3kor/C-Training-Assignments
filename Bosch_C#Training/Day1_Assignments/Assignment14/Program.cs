namespace Assignment14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //14)	Write a program to accept a number from user and find its absolute value.
            //Absolute always returns a positive value.

            Console.WriteLine("Enter a number");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine($"{-1 * number}");


            }
            else { Console.WriteLine($"{number}"); }

        }
    }
}
