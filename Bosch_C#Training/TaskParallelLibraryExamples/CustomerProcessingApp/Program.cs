namespace CustomerProcessingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Customer Credit Processing App");
            Task<List<Customer>> upgardeCustomersList = Task<List<Customer>>.Run(() =>
            {
                Task.Delay(1000).Wait();
                return new List<Customer>
                {
                    new Customer() {CustomerId = 1, ContactName="Alisha C.",City="Bangalore",CreditAmount=1200},
                    new Customer() {CustomerId = 2, ContactName="John Mark",City="Bangalore",CreditAmount=3200},
                    new Customer() {CustomerId = 3, ContactName="Pravinkumar R. D.",City="Pune",CreditAmount=900},
                    new Customer() {CustomerId = 4, ContactName="Manish Kaushik",City="Raipur",CreditAmount=1200}
                };
            }).ContinueWith((customers) =>
            {
                return customers.Result.Where(c => c.City=="Bangalore").ToList();
            }).ContinueWith(customers =>
            {
            foreach (var customer in customers.Result)
            {
                customer.CreditAmount = customer.CreditAmount + customer.CreditAmount*10/100;
            }
            return customers.Result;
            });

            foreach (var customer in upgardeCustomersList.Result)
            {
                Console.WriteLine($"customer {customer.ContactName} has credit amount {customer.CreditAmount} who is from {customer.City}");
            }
        }
    }
}
