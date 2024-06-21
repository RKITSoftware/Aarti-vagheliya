using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Middleware_Filter_Integration.BusinessLogic;
using Middleware_Filter_Integration.Filter;

namespace Middleware_Filter_Integration.Middleware
{
    /// <summary>
    /// Middleware for authorization.
    /// </summary>
    public class AuthorizationMiddleware
    {
        #region Private Member

        /// <summary>
        /// Delegate representing the next middleware in the request pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Connection factory for database operations.
        /// </summary>
        private readonly BLConnection _dbConnection;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next request delegate.</param>
        /// <param name="connection">The database connection factory.</param>
        public AuthorizationMiddleware(RequestDelegate next, BLConnection connection)
        {
            _next = next;
            _dbConnection = connection;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Invokes the middleware asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            var filter = new AuthorizationFilter(_dbConnection);
            var filterContext = new AuthorizationFilterContext(
                new ActionContext
                {
                    HttpContext = context,
                    RouteData = context.GetRouteData(),
                    ActionDescriptor = new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
                },
                new List<IFilterMetadata>()
            );

            filter.OnAuthorization(filterContext);

            if (filterContext.Result != null)
            {
                context.Response.StatusCode = (int)(filterContext.Result as UnauthorizedResult)?.StatusCode;
                return;
            }

            await _next(context);
        }

        #endregion
    }
}
