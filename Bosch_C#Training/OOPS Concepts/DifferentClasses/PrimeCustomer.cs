namespace DifferentClasses
{
    //PrimeCustomer is a Customer
    internal sealed class PrimeCustomer: Customer
    {
        public PrimeCustomer()
        {
            Console.WriteLine("Sealed Class Prime customer - Customer Constructer Executed!");
        }

        public double Fees { get; set; } = 1500;
    }
}
