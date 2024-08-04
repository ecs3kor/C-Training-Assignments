namespace Assignment15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //15)	Write a program to display ASCII characters in the range (0-255).
            //Pause after displaying every 10 characters.

            for(int i = 0; i <= 255; i++)
            {
                Console.Write("ASCII {0,3}: {1}", i,(char)i);
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); 
                }
            }
        }
    }
}
