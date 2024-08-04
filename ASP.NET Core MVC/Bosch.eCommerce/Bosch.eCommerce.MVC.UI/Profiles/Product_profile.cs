using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.MVC.UI.DTOs.ProductDtos;
using System.CodeDom;

namespace Bosch.eCommerce.MVC.UI.Profiles
{
    public class Product_profile:Profile
    {
        public Product_profile()
        {
            //Fetch
            CreateMap<Product, ProductDto>();
        }
    }
}
