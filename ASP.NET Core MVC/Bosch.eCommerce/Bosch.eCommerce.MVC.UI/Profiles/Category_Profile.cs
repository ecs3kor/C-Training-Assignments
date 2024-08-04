using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.MVC.UI.DTOs.CategoryDtos;

namespace Bosch.eCommerce.MVC.UI.Profiles
{
    public class Category_Profile:Profile 
    {
        public Category_Profile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<InsertCategoryDto, Category>();

        }
    }
}
