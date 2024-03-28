namespace Middleware_BasicDemo
{
    /// <summary>
    /// Custom middleware to write a message to the response.
    /// </summary>
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMiddleware"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the middleware to write a message to the response.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Hello from Custom-Middleware.");
            await next(context);
        }
    }
}
