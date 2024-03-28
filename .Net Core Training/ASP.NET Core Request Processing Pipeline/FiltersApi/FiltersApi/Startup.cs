using FiltersApi.Filters;
using Microsoft.OpenApi.Models;

namespace FiltersApi
{
    /// <summary>
    /// This class is responsible for configuring the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            //Add controller services
            services.AddControllers(option =>
            {
                // Add the exception filter globally to handle exceptions in controllers
                option.Filters.Add<ExceptionFilter>();
            });

            // Add memory cache service
            services.AddMemoryCache();

            // Add singleton instance of ResourceFilter
            services.AddSingleton<ResourceFilter>();

            // Add singleton instance of ActionFilter
            services.AddSingleton<ActionFilter>();

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
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting environment.</param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers();
            });
        }
    }
}
