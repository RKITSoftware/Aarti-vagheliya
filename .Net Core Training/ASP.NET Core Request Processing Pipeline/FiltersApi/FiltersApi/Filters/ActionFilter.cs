using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApi.Filters
{
    /// <summary>
    /// Action filter for validating request data.
    /// </summary>
    public class ActionFilter : Attribute, IActionFilter 
        //, IAsyncActionFilter
    {
    
        //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    await context.HttpContext.Response.WriteAsJsonAsync(new
        //    {
        //        Message = "Async Method Executed."
        //    });

        //}

        /// <summary>
        /// Executed before the action method.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
           var country = context.HttpContext.Request.Body;

            if (country != null)
            {
                // Data is present, continue execution
                return;
            }
            else
            {
                // Data is null, return a bad request response
                context.Result = new BadRequestObjectResult("Data is Null.");
                return;
            }
        }

        /// <summary>
        /// Executed after the action method.
        /// </summary>
        /// <param name="context">The action executed context.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Modify the response if necessary
            if (context.Result is ObjectResult objectResult)
            {
                context.Result = new ObjectResult(objectResult);
            }
        }
    }
}
