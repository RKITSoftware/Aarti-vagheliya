using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace FiltersApi.Filters
{
    /// <summary>
    /// A resource filter that caches responses.
    /// </summary>
    public class ResourceFilter : IResourceFilter , IAsyncResourceFilter
    {
        /// <summary>
        /// Instance of ImemoryCache Interface
        /// </summary>
        private readonly IMemoryCache _objCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceFilter"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        public ResourceFilter(IMemoryCache memoryCache)
        {
            _objCache = memoryCache;
        }

        /// <summary>
        /// Executes asynchronously before the resource executes.
        /// </summary>
        /// <param name="context">The resource executing context.</param>
        /// <param name="next">The delegate representing the remaining middleware pipeline.</param>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            try
            {
                // Cache the response asynchronously
                _objCache.Set("ResultAsync", "Cached response asynchoronous", DateTime.Now.AddMinutes(5));

                await next();
                var result = _objCache.Get("ResultAsync");
                //Console.WriteLine(result);
                context.Result = new ObjectResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executes after the resource executes.
        /// </summary>
        /// <param name="context">The resource executed context.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            try
            {
                var result = _objCache.Get("Result");
                context.Result = new ObjectResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executes before the resource executes.
        /// </summary>
        /// <param name="context">The resource executing context.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            try
            {
                var result = context.HttpContext.Response.Body;
                _objCache.Set("Result", "Cached response", DateTime.Now.AddMinutes(5));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
