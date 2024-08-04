using Solid__Principle;

namespace PurchaseOrder.Models
{
    public class Supplier: MerchantDetails
    {
        private readonly IInvoiceGenerator _invoiceGenerator;

        public Supplier(IInvoiceGenerator invoiceGenerator)
        {
            _invoiceGenerator = invoiceGenerator;            
        }

        public int SupplierCharges { get; set; }

        public double TotalSupplierPrice()

        {
            return _invoiceGenerator.TotalPrice() + SupplierCharges;
        }
    }
}
