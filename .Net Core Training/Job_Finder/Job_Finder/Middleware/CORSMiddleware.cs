namespace Job_Finder.Middleware
{
    /// <summary>
    /// Middleware for enabling Cross-Origin Resource Sharing (CORS) by adding appropriate headers to the HTTP response.
    /// </summary>
    public class CORSMiddleware
    {
        #region Private Member

        /// <summary>
        /// Represents the delegate representing the next middleware in the pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CORSMiddleware class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        public CORSMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Adds CORS headers to the HTTP response.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*"); // Allow requests from any origin

            // Optionally, you can specify allowed headers and methods
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");

            return _next(httpContext);
        }

        #endregion
    }

    /// <summary>
    /// Extension method used to add the CORSMiddleware to the HTTP request pipeline.
    /// </summary>
    public static class CORSMiddlewareExtensions
    {
        /// <summary>
        /// Adds the CORSMiddleware to the HTTP request pipeline.
        /// </summary>
        /// <param name="builder">The application builder.</param>
        /// <returns>The application builder.</returns>
        public static IApplicationBuilder UseCORSMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CORSMiddleware>();
        }
    }
}
