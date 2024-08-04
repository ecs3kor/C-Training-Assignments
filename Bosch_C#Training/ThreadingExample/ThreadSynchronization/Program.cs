using System.Threading;

namespace ThreadSynchronization
{
    internal class Program
    {
        static int TicketNumbers = 1;
        static AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
        static AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started!");

            Console.WriteLine($"Main Thread id is - {Thread.CurrentThread.ManagedThreadId} !");
            Thread t1 = new Thread(new ThreadStart(Job1));
            Thread t2 = new Thread(new ThreadStart(Job2));
           
            t2.Start();
            t1.Start();

            autoResetEvent1.WaitOne();
            autoResetEvent2.WaitOne();
            Console.WriteLine("Main Method Ended!");
        }

        private static void Job1()
        {
            Console.WriteLine($"Job-1 Thread id is - {Thread.CurrentThread.ManagedThreadId} !");
            lock (o)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Job-1 - has distributed ticket number - {TicketNumbers} completed!");
                    TicketNumbers++;

                }
                autoResetEvent1.Set();
            }
            
        }
        private static void Job2()
        {
            Console.WriteLine($"Job-2 Thread id is - {Thread.CurrentThread.ManagedThreadId} !");
            lock (o)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Job-2 - has distributed ticket number - {TicketNumbers} completed!");
                    TicketNumbers++;
                }
                autoResetEvent2.Set();
            }
            
        }
    }
}
