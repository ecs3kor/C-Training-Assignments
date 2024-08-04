using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.MVC.UI.DTOs.CategoryDtos;
using Bosch.eCommerce.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bosch.eCommerce.MVC.UI.Areas.Categories.Controllers
{
    [Area("Categories")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public HomeController(ICommonRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Cagtegories List";
            
            var categories =_mapper.Map<IEnumerable<CategoryDto>>( await _categoryRepository.GetAllAsync());
            return View(categories);
        }

        //GET - Method
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }
        //POST Method
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(InsertCategoryDto category) //Model binding
        {
            var new_category = _mapper.Map<Category>(category);
            if (ModelState.IsValid)
            {
                int result = await _categoryRepository.InsertAsync(new_category);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                // Log the validation errors
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        ModelState.AddModelError("", $"Validation error on '{key}': {error.ErrorMessage}");
                        Debug.WriteLine($"Validation error on '{key}': {error.ErrorMessage}");
                    }
                }

                // Output the state of the model to the debug console
                Debug.WriteLine("CategoryName: " + category.CategoryName);
                Debug.WriteLine("Description: " + category.Description);
            }
            return View();
        }

    }
}
