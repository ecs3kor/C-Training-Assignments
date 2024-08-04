using Microsoft.AspNetCore.Mvc;

namespace Bosch.eCommerce.MVC.UI.Areas.Security.Controllers
{
    [Area("Security")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
