using System.Text;

namespace Middleware_BasicAuthentication.Middleware
{
    /// <summary>
    /// Middleware for basic authentication.
    /// </summary>
    public class BasicAuthenticationHandler
    {
        private readonly RequestDelegate _next;

        //, string relm
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="next">The request delegate representing the next middleware in the pipeline.</param>
        /// <param name="realm">The realm for the basic authentication.</param>
        public BasicAuthenticationHandler(RequestDelegate next)
        {
            _next = next;
        }


        /// <summary>
        /// Handles the HTTP request.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                // Respond with unauthorized status code if Authorization header is missing
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Unauthorized."
                });
                return;
            }

            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCred = header.Substring(6);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCred));
            string[] userNamePassword = credentials.Split(":");
            string username = userNamePassword[0];
            string password = userNamePassword[1];

            // Check if the provided credentials match the expected values
            if (username != "Arti" || password != "123")
            {
                // Respond with unauthorized status code if credentials are invalid
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Invalid Credentials."
                });
                return;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
