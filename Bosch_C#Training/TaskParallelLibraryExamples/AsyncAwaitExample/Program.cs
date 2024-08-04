namespace AsyncAwaitExample
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var AllCustomers = await getDBCustomerAsync();
            var FilterCustomers = await FilterCustomersAsync(AllCustomers,"Bengaluru");
            var UpgradedCustomers = await IncreaseCreditAsync(FilterCustomers);

            foreach(var customer in UpgradedCustomers) {

        }

        private async static Task<List<Customer>> getDBCustomerAsync()
        {
            Task.Delay(1000).Wait();
            return await Task<List<Customer>>.FromResult(new List<Customer>()
            {
                new Customer() {CustomerId = 1, ContactName="Alisha C.",City="Mumbai",CreditAmount=1200},
                new Customer() {CustomerId = 2, ContactName="John Mark",City="Mumbai",CreditAmount=3200},
                new Customer() {CustomerId = 3, ContactName="Pravinkumar R. D.",City="Pune",CreditAmount=900},
                new Customer() {CustomerId = 4, ContactName="Manish Kaushik",City="Raipur",CreditAmount=1200}
            });

        }

        private async static Task<List<Customer>> FilterCustomersAsync(List<Customer> customers, string city)
        {
            return await Task<List<Customer>>.FromResult(customers.Where(c => c.City == city).ToList());
        }

        private async static Task<List<Customer>> IncreaseCreditAsync(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                customer.CreditAmount = customer.CreditAmount + (customer.CreditAmount * 20 / 100) ;
            }
            return await Task<List<Customer>>.FromResult(customers);
        }
    }
}
