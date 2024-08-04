using Microsoft.AspNetCore.Mvc;

namespace Bosch.eCommerce.MVC.UI.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
