namespace WorkingWithStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\ECS3KOR\\Documents\\Bosch- C#Training\\Messages.txt";
            //using (StreamWriter SW= new StreamWriter(filePath, true))
            //{
            //    SW.WriteLine("Welcome to India!");
            //    SW.WriteLine("Welcome to Karnataka!");
            //    SW.WriteLine("Welcome to Bangalore!");
            //    SW.WriteLine("Welcome to Bosch!");
            //    SW.Close();
            //}

            using (StreamReader sr = new StreamReader(filePath))
            {
                //Console.WriteLine(sr.ReadToEnd());
                while (sr.Peek() != -1)
                {
                    Console.WriteLine(sr.ReadLine());
                    Console.ReadKey();
                } 
                sr.Close();
            }
        }
    }
}
