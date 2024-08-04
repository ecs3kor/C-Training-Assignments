using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.eCommerce.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public DateTime CartDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
