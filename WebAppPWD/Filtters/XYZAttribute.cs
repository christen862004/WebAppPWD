using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppPWD.Filtters
{
    public class XYZAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //code
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //code
        }
    }
}
