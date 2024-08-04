namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the marks of Student 1:");
            double sum = 0,m1;
            for(int i=0;i<5;i++)
            {
                Console.WriteLine($"Please enter Mark{i+1}");
                m1 = double.Parse(Console.ReadLine());
                sum += m1;
            }
            Console.WriteLine($"The average score of Student1 = { sum / 5}");
        }
    }
}
