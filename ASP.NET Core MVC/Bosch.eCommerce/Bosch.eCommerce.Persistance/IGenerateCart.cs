using Bosch.eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.eCommerce.Persistance
{
    public interface IGenerateCart
    {
        Task<int> GenerateNewCart(int customerId);
        Task<List<MyCartVM>> GetCartItems(int cartId);
    }
}
