using Microsoft.AspNetCore.Diagnostics;

namespace Exception_Handling
{
    /// <summary>
    /// Statrtup class for configuring the application.
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Configures services for the application.
        /// </summary>
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddSwaggerGen();
        }

        /// <summary>
        /// Configures the application's request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // In development environment, use DeveloperExceptionPage middleware
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 3 // Limit the number of source code lines displayed in exception details
                };

                //Passing DeveloperExceptionPageOptions Instance to UseDeveloperExceptionPage Middleware Component
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);

                ////Default Exceptionpage Middleware
                //  app.UseDeveloperExceptionPage();

                // Enable Swagger UI for API documentation
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                ////Default error handling
                //app.UseExceptionHandler();

                // In production environment, use custom error handling
                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    // Custom logic for handling the exception
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("<html><body>\r\n");
                    await context.Response.WriteAsync("Custom Error Page<br><br>\r\n");

                    // Display custom error details
                    await context.Response.WriteAsync($"<strong>Error:</strong> {exception.Message}<br>\r\n");
                    await context.Response.WriteAsync("</body></html>\r\n");
                }));
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
