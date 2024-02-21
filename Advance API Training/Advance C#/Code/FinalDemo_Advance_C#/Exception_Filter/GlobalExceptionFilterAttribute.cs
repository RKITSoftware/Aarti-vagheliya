using FinalDemo_Advance_C_.Bussiness_Logic;
using System;
using System.Web.Http.Filters;

namespace FinalDemo_Advance_C_.Exception_Filter
{
    /// <summary>
    /// Global exception filter attribute to log exceptions.
    /// </summary>
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Public Method

        /// <summary>
        /// Overrides the OnException method to handle exceptions globally.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the HTTP action that throws the exception.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if(actionExecutedContext.Exception is Exception)
            {
                // Log the exception to a file using the BLFileLogger class
                BLFileLogger.LogException(actionExecutedContext.Exception);
            }

            

        }

        #endregion
    }
}