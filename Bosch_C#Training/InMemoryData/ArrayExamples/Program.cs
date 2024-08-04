namespace ArrayExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1-D Array Example!");
            Console.WriteLine();
            string[] offices = new string[3]; //{ "Bangalore", "Chennai", "Delhi" };
            offices[0] = "Bangalore";
            offices[1] = "Coimbatore";
            offices[2] = "Pune";
            for (int i = 0; i < offices.Length; i++)
            {
                Console.WriteLine(offices[i]);
            }

            //2-D array
            Console.WriteLine();
            Console.WriteLine("2-D Array Example!");
            Console.WriteLine();


            double[,] data = new double[2, 3] { { 1, 2, 3 }, { 1, 2, 4 } };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write($"{data[i,j]} \t");
                }
                Console.WriteLine();
            }

            //Jagged Array
            Console.WriteLine();
            Console.WriteLine("Jagged Array Example!");
            Console.WriteLine();

            string[][] subjects = new string[4][];
            subjects[0] = new string[] { "Subject1", "Subject2" };
            subjects[1] = new string[] { "Subject2", "Subject3","Subject4" };
            subjects[2] = new string[] { "Subject1", "Subject2", "Subject4", "Subject5" };
            subjects[3] = new string[] { "Subject1", "Subject2", "Subject4", "Subject5", "Subject3" };

            for(int i = 0;i < subjects.GetLength(0); i++)
            {
                for(int j = 0;j < subjects[i].Length; j++)
                {
                    Console.Write($"{subjects[i][j]} \t" );
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
