using System;

namespace Assignment21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*21)	Write a menu driven program, which allows user to select one of the following shapes – 
            a.Square
            b.Circle
            c.Rectangle
            And perform any of the operations on it.
            i.Calculate area.
            ii.Calculate perimeter.
            iii.Calculate area and perimeter both.
            Print the result in main.
            */

            Console.WriteLine("Select a shape:\n a) Square \n b) Circle \n c) Rectangle");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "a":
                case "square":
                    Console.WriteLine("Enter the side length:");
                    int length = int.Parse(Console.ReadLine());
                    CalculateSquare(length);
                    break;

                case "b":
                case "circle":
                    Console.WriteLine("Enter the radius:");
                    int radius = int.Parse(Console.ReadLine());
                    CalculateCircle(radius);
                    break;

                case "c":
                case "rectangle":
                    Console.WriteLine("Enter the length:");
                    int len = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the width:");
                    int wid = int.Parse(Console.ReadLine());
                    CalculateRectangle(len, wid);
                    break;

                default:
                    Console.WriteLine("Not a valid shape");
                    break;
            }
        }

        static void CalculateSquare(int length)
        {
            int area = length * length;
            int perimeter = 4 * length;
            Console.WriteLine($"Square - Area: {area}, Perimeter: {perimeter}");
        }

        static void CalculateCircle(int radius)
        {
            float pi = 3.142f;
            float area = pi * radius * radius;
            float perimeter = 2 * pi * radius;
            Console.WriteLine($"Circle - Area: {area}, Perimeter: {perimeter}");
        }

        static void CalculateRectangle(int length, int width)
        {
            int area = length * width;
            int perimeter = 2 * (length + width);
            Console.WriteLine($"Rectangle - Area: {area}, Perimeter: {perimeter}");
        }
    }
}
