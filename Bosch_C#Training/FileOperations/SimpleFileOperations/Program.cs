namespace SimpleFileOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @'C:\Users\ECS3KOR\Documents\Bosch- C#Training\Log.txt'
            if (!File.Exists(filepath))
            {
                Console.WriteLine("File you are looking for does not exist!");
                File.Create(filepath);
            }
        }
    }
}
