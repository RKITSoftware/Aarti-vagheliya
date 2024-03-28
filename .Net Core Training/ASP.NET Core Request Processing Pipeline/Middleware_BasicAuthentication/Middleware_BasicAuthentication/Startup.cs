using Microsoft.OpenApi.Models;
using Middleware_BasicAuthentication.Middleware;

namespace Middleware_BasicAuthentication
{
    /// <summary>
    /// Configures the application's services and HTTP request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers and API explorer
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            // Configure Swagger for Basic Authentication
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
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application's request processing pipeline.</param>
        /// <param name="env">The web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable developer exception page and Swagger UI
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                // Handle errors and enable HTTPS redirection in production
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Enable HTTPS redirection, routing, authentication, and authorization
            app.UseHttpsRedirection();
            app.UseRouting(); 
            app.UseAuthentication();
            app.UseAuthorization();

            // Add custom basic authentication middleware
            app.UseMiddleware<BasicAuthenticationHandler>();

            // Map controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
