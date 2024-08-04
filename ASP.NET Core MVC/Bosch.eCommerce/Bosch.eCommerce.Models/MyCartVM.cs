using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.eCommerce.Models
{
    public class MyCartVM
    {
        public int CartItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public int Discount { get; set; }
        public double DiscountedAmount { get; set; }
        public DateTime CartDate { get; set; }

    }
}
