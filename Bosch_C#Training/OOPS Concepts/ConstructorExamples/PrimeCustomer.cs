namespace ConstructorExamples
{
    //Prime cutomer IS-A Customer
    internal class PrimeCustomer : Customer
    {
        public PrimeCustomer()
        {
            Console.WriteLine("Default Constructor of Prime Customer!");
        }

        public PrimeCustomer(string name, string city):base(name, city) 
        { 
            
        }
    }
}
