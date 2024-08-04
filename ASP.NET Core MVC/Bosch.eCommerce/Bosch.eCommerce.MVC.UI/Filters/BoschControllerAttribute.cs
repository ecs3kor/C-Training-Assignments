using Microsoft.AspNetCore.Mvc.Filters;

namespace Bosch.eCommerce.MVC.UI.Filters
{
    public class BoschControllerAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("I am controller action method : On Executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("I am controller action method : On Executing");
        }
    }
}
