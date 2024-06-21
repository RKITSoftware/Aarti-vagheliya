using Job_Finder.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Job_Finder.Middleware
{
    /// <summary>
    /// Middleware to handle exceptions globally within the application's HTTP request pipeline.
    /// </summary>
    public class ExceptionMiddleware
    {
        #region Private Member

        /// <summary>
        /// The delegate representing the next middleware component in the request pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// The logger instance used for logging exceptions within the middleware.
        /// </summary>
        private readonly ILogger<ExceptionFilter> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        /// <param name="logger">The logger instance to log exceptions.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionFilter> logger)
        {
            _next = next;
            _logger = logger;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Invokes the middleware to handle exceptions asynchronously.
        /// </summary>
        /// <param name="httpContext">The HTTP context for the current request.</param>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unhandled exception occurred.");

                // Create an instance of your custom ExceptionFilter
                var filter = new ExceptionFilter(_logger); // Instantiate your custom ExceptionFilter here

                // Create an ActionContext (or use an existing one depending on your needs)
                var actionContext = new Microsoft.AspNetCore.Mvc.ActionContext();

                // Create an ExceptionContext and assign the exception
                //var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) { Exception = ex };

                var exceptionContext = new ExceptionContext(
                    actionContext,
                    new List<IFilterMetadata>())
                    { Exception = ex};

                // Call OnException method of your custom ExceptionFilter
                filter.OnException(exceptionContext);

                // Rethrow the exception after handling/logging
                throw;
            }
        }

        #endregion
    }

    /// <summary>
    /// Extension method used to add the <see cref="ExceptionMiddleware"/> to the HTTP request pipeline.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExceptionMiddleware"/> to the HTTP request pipeline.
        /// </summary>
        /// <param name="builder">The application builder instance.</param>
        /// <returns>The updated application builder with the exception middleware added.</returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
