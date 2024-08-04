namespace CollectionAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (Customer customer in GetAllCustomer())
            {
                Console.WriteLine($"Customer {customer.ContactName} lives in city {customer.City}!");
            }

            Console.ReadKey();
        }
        private static List<Customer> GetAllCustomer()
        {
            return new List<Customer>()
    {
        new(){CustomerId = 1, ContactName="Alisha C.",City="Mumbai"},
        new(){CustomerId = 2, ContactName="Manas Jha",City="Mumbai"},
        new(){CustomerId = 3, ContactName="Maria Johns",City="London"},
        new(){CustomerId = 4, ContactName="John Marks",City="Berlin"},
    };
        }
    }
}
