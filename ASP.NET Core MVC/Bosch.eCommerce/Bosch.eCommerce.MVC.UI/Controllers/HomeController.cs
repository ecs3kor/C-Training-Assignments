using Bosch.eCommerce.MVC.UI.Filters;
using Bosch.eCommerce.MVC.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;


namespace Bosch.eCommerce.MVC.UI.Controllers
{
    [BoschController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [BoschAction]
        public IActionResult Index()
        {
            Cookie cookie = new Cookie();
            cookie.Secure = true;
            
            HttpContext.Response.Cookies.Append("Company", "Bosch.Pvt.Lmt");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
