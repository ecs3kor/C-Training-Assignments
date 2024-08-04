namespace Assigment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the marks of Student 1:");
            double sum = 0, m1;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Please enter Mark{i + 1}");
                m1 = double.Parse(Console.ReadLine());
                sum += m1;
            }
            Console.WriteLine($"Total score of Student1 = {sum}");
        }
    }
}
