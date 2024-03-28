using FiltersApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApi.Filters
{
    /// <summary>
    /// A result filter that adds a custom header to the response.
    /// </summary>
    public class ResultFilter : ResultFilterAttribute
    {

        /// <summary>
        /// The name of the custom header to add.
        /// </summary>
        private readonly string _headerName;

        /// <summary>
        /// The value of the custom header to add.
        /// </summary>
        private readonly string _headerValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultFilter"/> class with the specified header name and value.
        /// </summary>
        /// <param name="headerName">The name of the custom header to add.</param>
        /// <param name="headerValue">The value of the custom header to add.</param>
        public ResultFilter(string headerName, string headerValue)
        {
            _headerName = headerName;
            _headerValue = headerValue;
        }

        /// <summary>
        /// Executes before the result executes.
        /// </summary>
        /// <param name="context">The result executing context.</param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                // Check if the value is a list of CNT01 objects
                if (objectResult.Value is List<CNT01> listOfObjects)
                {
                    // Add the custom header
                    context.HttpContext.Response.Headers.Add(_headerName, _headerValue);
                    // Update the context.Result with the modified value
                    context.Result = new ObjectResult(listOfObjects);
                }

            }
            base.OnResultExecuting(context);
        }
    }
}
