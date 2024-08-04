namespace DifferentClasses
{
    //you cannot create an instance of the abstract class
    //abstract classses can contain abstract methid but non-abstarct classes cannot contain abstract methods
    abstract class Person
    {
        //required or question mark means that it is not nullable
        public int SocialID { get; set; }
        public required string ContactName { get; set; } 
        public required string Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public required string Email { get; set; }

        protected Person()
        {
            Console.WriteLine("Abstract class constructor got executed!");
        }
        public abstract bool ChangeAddress(string oldaddress, string newaddress);

    }
}
