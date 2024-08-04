using Bosch.eCommerce.DAL;
using Bosch.eCommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.eCommerce.Persistance
{
    public class GenerateCart : IGenerateCart
    {
        private readonly ECommerceDBContext _eCommerceDBContext;
        public GenerateCart(ECommerceDBContext eCommerceDBContext)
        {
            _eCommerceDBContext = eCommerceDBContext;
        }
        public async Task<int> GenerateNewCart(int customerId)
        {
            var customerIdParam = new SqlParameter()
            {
                ParameterName = "@p_CustomerId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = customerId
            };
            var cartIdParameter = new SqlParameter()
            {
                ParameterName = "@p_CartId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            await _eCommerceDBContext.Database.ExecuteSqlRawAsync("EXEC GenerateNewCart @p_CustomerId, @p_CartId OUTPUT", customerIdParam, cartIdParameter);
            return Convert.ToInt32(cartIdParameter.Value);
        }

        public async Task<List<MyCartVM>> GetCartItems(int cartId)
        {
            var cartDetailQuery = from cart in _eCommerceDBContext.Carts
            join
                                                        cartDetail in _eCommerceDBContext.CartItems
                                                        on cart.CartId equals cartDetail.CartId
            join
                                                        product in _eCommerceDBContext.Products
                                                        on cartDetail.ProductId equals product.ProductId
                                  where cart.CartId == cartId
                                  select new MyCartVM()
                                  {
                                      CartItemId = cartDetail.CartItemId,
                                      Discount = product.Discount,
                                      ProductName = product.ProductName,
                                      Quantity = cartDetail.Quantity,
                                      Size = cartDetail.Size,
                                      UnitPrice = product.UnitPrice,
                                      DiscountedAmount = product.UnitPrice - ((product.UnitPrice * product.Discount) / 100),
                                      CartDate = cart.CartDate
                                  };
            return await cartDetailQuery.ToListAsync();
        }
    }
}
