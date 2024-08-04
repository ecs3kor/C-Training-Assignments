namespace PurchaseOrder.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public Order Order { get; set; }

    }
}
