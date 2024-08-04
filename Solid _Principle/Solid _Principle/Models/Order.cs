namespace PurchaseOrder.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int Quantity {  get; set; }

        public double Price { get; set; } 
        public Product Product { get; set; }

        public Employee OrderProcessingEmployee { get; set; }

    }
}
