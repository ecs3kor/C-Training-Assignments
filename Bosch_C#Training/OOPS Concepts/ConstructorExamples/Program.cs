namespace ConstructorExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer customer = new("Alisha.c", "Mumbai");
            //Customer customer2 = new(customer);
            //Console.WriteLine(customer.GetCustomerInfo());
            //Console.WriteLine(customer2.GetCustomerInfo());
            //Console.ReadKey();

            //PrimeCustomer prime = new PrimeCustomer();
            PrimeCustomer primeCustomer = new("Shravani", "Hubli");
            Console.ReadKey();

        }
    }
}
