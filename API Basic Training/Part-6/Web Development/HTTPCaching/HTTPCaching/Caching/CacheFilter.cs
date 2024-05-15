using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace HTTPCaching.Caching
{
    /// <summary>
    /// A custom cache filter attribute for implementing caching in Web API actions.
    /// </summary>
    public class CacheFilter : ActionFilterAttribute
    {
        #region Public member

        /// <summary>
        /// Gets or sets the cache duration in seconds.
        /// </summary>
        public int Duration { get; set; }  // Cache duration in seconds

        #endregion

        #region Public method
        /// <summary>
        /// Called after the action method is executed, allowing the manipulation of the response.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the action executed.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Check if the response is not null
            if (actionExecutedContext.Response != null)
            {
                // Create a new CacheControlHeaderValue to set cache control directives
                var cacheControlHeader = new CacheControlHeaderValue
                {
                    // Indicates that the response may be cached by public caches
                    Public = true, 
                    // Specifies the maximum age of the response in seconds
                    MaxAge = TimeSpan.FromSeconds(Duration) 
                };

                // Set Cache-Control header in the response
                actionExecutedContext.Response.Headers.CacheControl = cacheControlHeader;

                // Set ETag header based on the computed ETag value
                actionExecutedContext.Response.Headers.ETag = new EntityTagHeaderValue("\"" + ComputeETag() + "\"");

                // Set Last-Modified header to the current UTC date and time
                actionExecutedContext.Response.Content.Headers.LastModified = new DateTimeOffset(DateTime.UtcNow);
            }

            base.OnActionExecuted(actionExecutedContext);
        }
        #endregion

        #region Private method

        /// <summary>
        /// Computes a unique ETag value.
        /// </summary>
        /// <returns>A string representing the computed ETag value.</returns>
        private string ComputeETag()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }

        #endregion
    }
}