namespace DifferentClasses
{
    //Customer IS-A Person
    internal class Customer : Person
    {
        public Customer() {
            Console.WriteLine("Concrete Class-Customer Constructor executed!");
        }

        public int CustomerID { get; set; }

        public override bool ChangeAddress(string oldaddress, string newaddress)
        {
            Console.WriteLine($"Person {ContactName} has changed his/her address from {oldaddress} to {newaddress}");
            return true;
        }
    }
}
