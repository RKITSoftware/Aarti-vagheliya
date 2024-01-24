using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Exception.CustomException
{
    /// <summary>
    /// Custom exception handler for handling exceptions and providing appropriate responses.
    /// </summary>
    public class CustomExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Overrides the HandleAsync method to handle exceptions and customize the response.
        /// </summary>
        /// <param name="context">The context containing information about the exception.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            // Default values for status code and error message
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMsg = string.Empty;

            // Check if the exception context is not null
            if (context.Exception != null)
            {
                // Get the filtered exception
                System.Exception FilteredException = context.Exception;

                // Customize response based on the type of filtered exception
                if (FilteredException.GetType() == typeof(NullReferenceException)
                    ||FilteredException.GetType() == typeof(ArgumentNullException))
                {
                    statusCode = HttpStatusCode.NotFound;
                    errorMsg = "Requested data not found.";
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    errorMsg = "Application cannot process the request at moment..!";
                }
            }
            // Create the final response
            var response = context.Request.CreateResponse(statusCode, errorMsg);

            // Add custom header to the response
            response.Headers.Add("X-Error", "Freom exception Handler");

            // Set the custom response as the result in the context
            context.Result = new ResponseMessageResult(response);

            // Call the base method
            await base.HandleAsync(context, cancellationToken);
        }
    }
}