using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace FinalDemo_WebAPI.CustomException
{
    /// <summary>
    /// Custom exception filter for handling exceptions in Web API.
    /// </summary>
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        #region Public Method
        
        /// <summary>
        /// Overrides the OnException method to handle exceptions and provide custom responses.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the action executed.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Default values for status code and error message
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMsg = string.Empty;

            // Get the type of the exception
            var exceptionType = actionExecutedContext.Exception.GetType();

            // Switch statement to handle different types of exceptions
            switch (exceptionType.Name)
            {
                case nameof(UnauthorizedAccessException):
                    errorMsg = "Unauthorized Access..";
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case nameof(ArgumentNullException):
                    errorMsg = "Argument is null....";
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case nameof(ArgumentOutOfRangeException):
                    errorMsg = "Argument Out of Range .....";
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case nameof(NotImplementedException):
                    errorMsg = " Data is not found becuase not implemented .... ";
                    statusCode = HttpStatusCode.NotImplemented;
                    break;
                case nameof(FormatException):
                    errorMsg = " Formate is not Valid .... ";
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case nameof(ValidationException):
                    errorMsg = " Not Validate .... ";
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case nameof(DllNotFoundException):
                    errorMsg = " Dll is not found  .... ";
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    errorMsg = " Internal server Error. Contact to admin... ";
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            // Create a custom response message
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errorMsg),
                ReasonPhrase = "From Excption Filter."
            };

            // Set the custom response to the action executed context
            actionExecutedContext.Response = response;
            actionExecutedContext.Response.StatusCode = statusCode;

            base.OnException(actionExecutedContext);
        }

        #endregion
    }
}