namespace First_MVC_App.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Quantity{ get; set; }
        public int EmployeeId { get; set; }
    }
}
