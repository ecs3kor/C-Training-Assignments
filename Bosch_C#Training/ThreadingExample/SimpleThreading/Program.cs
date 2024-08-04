namespace SimpleThreading
{
    internal class Program
    {
        static AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
        static AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started!");

            Console.WriteLine($"Main Thread id is - {Thread.CurrentThread.ManagedThreadId} !");
            Thread t1 = new Thread(new ThreadStart(Job1));
            Thread t2 = new Thread(new ThreadStart(Job2));
            t2.Priority = ThreadPriority.Highest;
            t2.Start();
            t1.Start();
            //t1.Join();
            //t2.Join();
            autoResetEvent1.WaitOne();
            autoResetEvent2.WaitOne();
            Console.WriteLine("Main Method Ended!");
        }

        private static void Job1()
        {
            Console.WriteLine($"Job-1 Thread id is - {Thread.CurrentThread.ManagedThreadId} !");
            for (int i = 0; i < 10; i++)
            {
                //Thread.Sleep(10);
                Console.WriteLine($"Job-1 - Task - {i} completed!");
            }
            autoResetEvent1.Set();
        }
        private static void Job2()
        {
            Console.WriteLine($"Job-2 Thread id is - {Thread.CurrentThread.ManagedThreadId} !");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Job-2 - Task - {i} completed!");
            }
            autoResetEvent2.Set();
        }
    }
}
