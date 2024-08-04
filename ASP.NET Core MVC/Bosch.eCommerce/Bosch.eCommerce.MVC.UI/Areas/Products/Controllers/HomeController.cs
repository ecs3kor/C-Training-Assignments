using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.MVC.UI.DTOs.ProductDtos;
using Bosch.eCommerce.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.Design;

namespace Bosch.eCommerce.MVC.UI.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<Product> _productRepository;
        private readonly ICommonRepository<Category> _catRepo;
        private readonly IMemoryCache _productsCache;
        private readonly IMapper _products_map;



        public HomeController(ICommonRepository<Product> productRepository, ICommonRepository<Category> categoryRepository, IMemoryCache productsCache, IMapper products_map)
        {
            _productRepository = productRepository;
            _catRepo = categoryRepository;
            _productsCache = productsCache;
            _products_map = products_map;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
        {
            ViewBag.PageTitle = "Products List";
            

            /*           IEnumerable<Product> cachedProducts;
                       if(_productsCache.TryGetValue("ProductsList",out cachedProducts))
                       {
                           return View(cachedProducts);
                       }
                       MemoryCacheEntryOptions cacheOptions = new()
                       {
                           AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2),
                           SlidingExpiration = new TimeSpan(0, 0, 40)
                       };
                       var products = await _productRepository.GetAllAsync();
                       _productsCache.Set("ProductList", products,cacheOptions);
                       return View(products);*/
            IEnumerable<ProductDto> cachedProducts;
            if (_productsCache.TryGetValue("ProductsList", out cachedProducts))
            {
                ViewBag.TotalProducts = cachedProducts.ToList().Count;
                ViewBag.PageSize = pageSize;
                var model1 = cachedProducts.ToList().Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return View(model1);
            }
            MemoryCacheEntryOptions cacheOptions = new()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2),
                SlidingExpiration = new TimeSpan(0, 0, 40)
            };
            var newProducts = _products_map.Map<IEnumerable<ProductDto>>(await _productRepository.GetAllAsync());
            //var products = await _productRepository.GetAllAsync();
            _productsCache.Set("ProductsList", newProducts, cacheOptions);

            ViewBag.TotalProducts = newProducts.ToList().Count;
            ViewBag.PageSize = pageSize;
            var model = newProducts.ToList().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return View(model);

            //return View(newProducts);
        }

        public async Task<IActionResult> Details(int id)
        {
            Console.WriteLine(id);
            var product = (await _productRepository.GetDetailsAsync(id));
            Console.WriteLine(product.ProductName);
            //ViewBag.PageTitle = "Details of - " + product.ProductName;
            var new_price = product.UnitPrice-((product.UnitPrice * product.Discount) / 100);
            ViewBag.new_price=new_price;
            return View("Details",product);
        }

        public async Task<IActionResult> CategoryWiseProducts(int id)
        {
            string catName = (await _catRepo.GetDetailsAsync(id)).CategoryName;
            ViewBag.PageTitle = "Products List " + catName;
            var products = _products_map.Map<IEnumerable<ProductDto>>(await _productRepository.GetAllAsync()).Where(product => product.CategoryId == id);
            return View("Index", products);
        }

    }
}
