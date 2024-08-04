namespace GenericCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int firstNumber = list.First();

            Stack<string> books = new Stack<string>();
            books.Push("Book1");
            books.Push("Book2");
            books.Push("Book3");
            books.Push("Book4");

            books.Pop();

            Queue<string> books2 = new Queue<string>();
            books2.Enqueue("book1");
            books2.Enqueue("book2");
            books2.Enqueue("book3");
            books2.Enqueue("book4");

            books2.Dequeue();
            books2.Peek();

            Dictionary<int,string> employees = new Dictionary<int,string>();
            employees.Add(1000, "Alisha C.");
            employees.Add(1001, "Ali C.");
            employees.Add(1002, "Alia C.");
            employees.Add(1003, "Aisha C.");

            foreach(int item in employees.Keys)
            {
                Console.WriteLine($"Employee Id {item} and name is {employees[item]}");
            }

            Console.ReadKey();



        }
    }
}
