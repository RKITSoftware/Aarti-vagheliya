namespace Middleware_BasicDemo
{
    /// <summary>
    /// Extension methods for configuring middleware in the application pipeline.
    /// </summary>
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Configures middleware components in the application pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        public static void UseExtension(IApplicationBuilder app)
        {
            // First middleware
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("<html><body>Response from first middleware.");
                await next();
                await context.Response.WriteAsync("<br>End of First middleware.</body></html>");
            });

            // Middleware to handle requests with specific query parameter
            app.UseWhen(c => c.Request.Query.ContainsKey("role"), a => {
                a.Run(async context => {
                    await context.Response.WriteAsync($"<br>Role is {context.Request.Query["role"]}");
                });
            });

            // Nested mapping for different paths
            app.Map("/map", a => {
                a.Map("/branch", x => {
                    x.Run(async context => {
                        await context.Response.WriteAsync("<br> New child Branch.");
                    });
                });
                a.Run(async context => {
                    await context.Response.WriteAsync("<br>New Branch map.");
                });
            });

            // Middleware to handle requests with specific query parameter conditionally
            app.MapWhen(c => c.Request.Query.ContainsKey("count"), a => {
                a.Run(async context =>
                {
                    await context.Response.WriteAsync($"<br>Count is {context.Request.Query["count"]}");
                });
            });

            // Default middleware
            app.Run(async context => {
                await context.Response.WriteAsync("<br>Response from second middleware.");
            });

        }
    }
}
