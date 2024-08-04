namespace DifferentClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Object initializer
            PrimeCustomer customer = new() { Address="Bangalore",ContactName="Shravani",City="Nagar",Phone="234567890",Email="shrav@gmail.com"};
            /*customer.ContactName = "Test";
            customer.Address = "bangalore";
            customer.City = "Test";
            customer.Email = "Test";
            customer.Phone = "Test";*/
            customer.ChangeAddress(customer.Address,"Pune");
            Console.WriteLine(customer.EarlyAccess(DateTime.Now.AddDays(3)));

            //namespace for partial classes should be same
            BoschCalci boschCalci = new BoschCalci();
            Console.WriteLine(boschCalci.Addition(10, 20));
            Console.WriteLine(boschCalci.Difference(10, 20));
            Console.WriteLine(boschCalci.Multiplication(10, 20));



        }
    }
}
