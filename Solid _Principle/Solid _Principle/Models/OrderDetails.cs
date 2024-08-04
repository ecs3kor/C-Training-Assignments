namespace PurchaseOrder.Models
{
    public class OrderDetails
    {
        public Order OrderInfo { get; set; }
        public Customer CustomerInfo { get; set; }

        public Invoice Invoice { get; set; }
        
    }
}
