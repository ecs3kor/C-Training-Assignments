using Solid__Principle;

namespace PurchaseOrder.Models
{
    public class Shipper: MerchantDetails
    {
        private readonly IInvoiceGenerator _invoiceGenerator;
        public Shipper(IInvoiceGenerator invoiceGenerator) 
        {
            _invoiceGenerator = invoiceGenerator;
        }

        public int ShippingCharges { get; set; }

        public double TotalShippingPrice()
        {
            return _invoiceGenerator.TotalPrice() + ShippingCharges;
        }
    }
}
