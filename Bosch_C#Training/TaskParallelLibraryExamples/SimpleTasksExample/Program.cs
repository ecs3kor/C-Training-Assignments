using System.Threading.Tasks;

namespace SimpleTasksExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            Console.WriteLine($"Main method started on {Thread.CurrentThread.ManagedThreadId}");
                        Task task = new Task(new Action(() => Console.WriteLine($"Task-1 started on {Thread.CurrentThread.ManagedThreadId}")));
                        task.Start();

                        Task<string> task2 = new Task<string>(() => "Welcome to Bosch");
                        task2.Start();
                        Console.WriteLine(task2.Result);*/


            /*            Task.Run(() =>
                        {
                            Console.WriteLine($"Task1 Startetd on {Thread.CurrentThread.ManagedThreadId}");
                        });

                        Task<int> task = Task.Run(() => 1000);
                        Console.WriteLine(task.Result);*/

            Task<int> t1 = Task.Run(() => { Task.Delay(3000).Wait(); return 1000; });
            Task<int> t2 = Task.Run(() => { Task.Delay(5000).Wait(); return 2000; });
            Task<int> t3 = Task.Run(() => { Task.Delay(8000).Wait(); return 3000; });
            //Task.WaitAll(t1, t2, t3);
            var task = Task.WhenAny(t1, t2, t3).Result;
            Console.WriteLine($"Task1 Value {t1.Result}");
            Console.WriteLine($"Task2 Value {t2.Result}");
            Console.WriteLine($"Task3 Value {t3.Result}");
            Console.WriteLine(task.Result);



        }
    }
}
