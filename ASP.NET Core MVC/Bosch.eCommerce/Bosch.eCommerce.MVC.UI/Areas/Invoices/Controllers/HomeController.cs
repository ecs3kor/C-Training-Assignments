using Microsoft.AspNetCore.Mvc;

namespace Bosch.eCommerce.MVC.UI.Areas.Invoices.Controllers
{
    [Area("Invoices")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
