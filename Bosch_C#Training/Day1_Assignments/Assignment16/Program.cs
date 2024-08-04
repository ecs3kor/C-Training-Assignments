using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //16)	Write a program to display whether a user entered number is a prime or no.
            //Modify the same program to display first 25 prime numbers using while loop.
            //Also write a same program using for and do-while loops.

                      // Console.WriteLine("Enter a number");
                       // int is_prime = 0;
            /*  int number = int.Parse(Console.ReadLine());
             if(number == 2)
             {
                 Console.WriteLine($"{number} is a prime number");
             }

             for(int i=2;i<=number/2;i++)
             {
                 if(number%i == 0)
                 {
                     is_prime = 1; break;
                 }

             }
             if(is_prime == 1)
             {
                 Console.WriteLine($"{number} is not a prime number");
             }
             else
             {
                 Console.WriteLine($"{number} is a prime number");
             }*/

            int number = 3;
            Console.WriteLine(2);
            while (number != 25)
            {
                int is_prime = 0;
                for (int i = 2; i <= number / 2; i++)
                {
                    if (number % i == 0)
                    {
                        is_prime = 1; break;
                    }

                }
                if (is_prime == 1)
                {
                    
                    number++;
                }
                else
                {
                    Console.WriteLine($"{number}");
                    number++;
                }
                
            }
            

        }
    }
}
