using Microsoft.OpenApi.Models;
using Middleware_Filter_Integration.BusinessLogic;
using Middleware_Filter_Integration.Middleware;

namespace Middleware_Filter_Integration
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the services for the application.
        /// This method is called by the runtime and is used to add services to the dependency injection container.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            // Add controllers to the service collection
            services.AddControllers();

            //services.AddScoped<AuthorizationMiddleware>();

            // Configure Swagger for API documentation
            services.AddSwaggerGen(c =>
            {
                // Add security definition for basic authentication
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "basic",
                    Type = SecuritySchemeType.Http,
                    Description = "Basic Authentication using the basic scheme"
                });

                // Add security requirement for basic authentication
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            // Add the BLConnection service as a singleton
            services.AddSingleton<BLConnection>();

            // Optional: Add the AuthorizationFilter service as a singleton
            //services.AddSingleton<AuthorizationFilter>();

        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// This method is called by the runtime and is used to define how the application responds to HTTP requests.
        /// </summary>
        /// <param name="app">An instance of IApplicationBuilder used to configure the request pipeline.</param>
        /// <param name="env">An instance of IWebHostEnvironment used to access the web hosting environment.</param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable developer exception page and Swagger UI in the development environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable serving static files
            app.UseStaticFiles();

            // Enable routing
            app.UseRouting();

            // Enable HTTPS redirection
            app.UseHttpsRedirection();

            // Enable authorization
            app.UseAuthorization();

            // Add the custom authorization middleware
            app.UseMiddleware<AuthorizationMiddleware>();

            // Configure the endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
