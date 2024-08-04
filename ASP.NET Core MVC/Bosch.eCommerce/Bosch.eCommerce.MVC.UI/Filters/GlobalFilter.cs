using Microsoft.AspNetCore.Mvc.Filters;

namespace Bosch.eCommerce.MVC.UI.Filters
{
    public class GlobalFilter:Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("I am Global Filter : On Executed Global Filter");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("I am Global Filter : On Executing Global Filter");
        }
    }
}
