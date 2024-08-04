using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    internal class Customer
    {
        public int CustomerId { get; set; }

        public string ContactName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
