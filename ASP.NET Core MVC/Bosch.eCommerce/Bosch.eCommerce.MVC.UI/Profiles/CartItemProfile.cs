using Bosch.eCommerce.Models;
using Bosch.eCommerce.MVC.UI.DTOs.CartItemDtos;
using AutoMapper;

namespace Bosch.eCommerce.MVC.UI.Profiles
{
    public class CartItemProfile:Profile
    {
        public CartItemProfile()
        {
            CreateMap<InsertCartItemDto, CartItem>();
        }
    }
}
