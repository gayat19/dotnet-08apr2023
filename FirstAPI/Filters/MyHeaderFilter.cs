using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstAPI.Filters
{
    public class MyHeaderFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Author", new string[] { "ABC" });
        }
    }
}
