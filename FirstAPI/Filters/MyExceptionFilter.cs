using FirstAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstAPI.Filters
{
    public class MyExceptionFilter : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           context.ExceptionHandled = true;
            context.Result = new JsonResult(new QuantityException());
        }
    }
}
