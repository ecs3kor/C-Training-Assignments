using Solid__Principle;

namespace PurchaseOrder.Models
{
    public class Invoice: IInvoiceGenerator
    {
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public double unitPrice { get; set; }
        public double finalPrice { get; set; }

        public double TotalPrice()
        {
            return (Quantity * unitPrice);
        }
    }
}
