using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Exception.CustomException
{
    /// <summary>
    /// Custom exception filter for handling specific exceptions and providing appropriate responses.
    /// </summary>
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Overrides the OnException method to handle exceptions and customize the response.
        /// </summary>
        /// <param name="actionExecutedContext">The context of the executed HTTP action, including the exception.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Default values for status code and error message
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMsg = string.Empty;

            // Get the type of the exception
            var exceptionType = actionExecutedContext.Exception.GetType();

            // Customize response based on the type of exception
            if (exceptionType == typeof(UnauthorizedAccessException) )
            {
                errorMsg = "Unauthorized Access..";
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                errorMsg = " Data is not found becuase not implemented .... ";
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                errorMsg = " Contact to admin...";
                statusCode = HttpStatusCode.InternalServerError;
            }

            // Create a custom response message
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errorMsg),
                ReasonPhrase = "From Excption Filter."
            };

            // Set the custom response to the action executed context
            actionExecutedContext.Response = response;

            // Call the base method
            base.OnException(actionExecutedContext);
        }
    }
}