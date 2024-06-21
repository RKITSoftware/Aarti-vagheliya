using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Job_Finder.Filters
{
    /// <summary>
    /// Exception filter for handling unhandled exceptions in ASP.NET Core MVC applications.
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        #region Private Member

        /// <summary>
        /// Logger instance used for logging exceptions.
        /// </summary>
        private readonly ILogger<ExceptionFilter> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger instance to log exceptions.</param>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Handles the exception and creates a standardized error response for API clients.
        /// </summary>
        /// <param name="context">The exception context containing information about the exception and the action context.</param>
        public void OnException(ExceptionContext context)
        {
            // Log the exception details
            _logger.LogError(context.Exception, "An unhandled exception occurred");

            // Create a standardized error response
            var errorResponse = new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                MethodName = context.ActionDescriptor.DisplayName,
                Message = "An unexpected error occurred. Please try again later.",
                Detailed = context.Exception.Message // Optionally include exception details for debugging
            };

            // Set the result as a JSON response
            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }

        #endregion
    }
}
