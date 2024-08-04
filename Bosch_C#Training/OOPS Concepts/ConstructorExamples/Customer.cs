namespace ConstructorExamples
{
    internal class Customer
    {
        static Customer() {
            Console.WriteLine("This is Static constructor of cutomer class!");
        
        }
        public Customer() {
            CustomerID = -1;
            Console.WriteLine("Defult Constructor of Customer Class!");
        }
        public Customer(string name, string city):this()
        {
            CustomerName = name;
            City = city;
            Console.WriteLine("Parameterized Constructor of Customer Class!");
        }

        public Customer(Customer customer)
        {
            City = customer.City;
            CustomerName = customer.CustomerName;

        }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } =string.Empty;
        public string City { get; set; } = string.Empty;
        protected int PinNumber { get; set; }

        public string GetCustomerInfo()
        {
            return $"Customer {CustomerName} lives in city {City}.";
        }

    }
}
