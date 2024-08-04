using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentClasses
{
    //All extension methods are static classes and all extension methods are by default static
    internal static class PrimeCustomereExtensionMethods
    {
        public static string EarlyAccess(this PrimeCustomer customer,DateTime startDate) 
        {
            return $"Prime Early access starts from {startDate}";
        } 
    }
}
