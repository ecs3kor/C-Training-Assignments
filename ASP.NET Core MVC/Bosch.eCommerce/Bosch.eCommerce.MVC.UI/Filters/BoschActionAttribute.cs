using Microsoft.AspNetCore.Mvc.Filters;

namespace Bosch.eCommerce.MVC.UI.Filters
{
    public class BoschActionAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"I am Action Method Filter - OnActionExecuted");
            context.HttpContext.Response.Headers.Add("X-Bosch-Certificate", "Bosch.AbcProduct.V.10.29.90");
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"I am Action Method Filter - OnActionExecuting");
        }
    }
}
