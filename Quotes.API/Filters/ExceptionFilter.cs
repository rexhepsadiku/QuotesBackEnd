using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Quotes.Application.Wrappers;

namespace Quotes.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exResult = new ExceptionResponse(context.Exception);
            context.Result = new JsonResult(exResult);
            context.HttpContext.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }
    }
}
