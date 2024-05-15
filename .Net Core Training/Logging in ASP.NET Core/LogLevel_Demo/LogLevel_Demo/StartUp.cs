using LogLevel_Demo.BusinessLogic;
using LogLevel_Demo.Interface;

namespace LogLevel_Demo
{
    /// <summary>
    /// This class configure the application
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Configures the services required by the application.
        /// </summary>
        /// <param name="service">The collection of services to configure.</param>
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddSwaggerGen();
            //service.AddLogging(logging =>
            //{
            //    logging.SetMinimumLevel(LogLevel.Trace);
            //    logging.AddNLog();
            //});

            // Add scoped service for order service interface and implementation
            service.AddScoped<IOrderService, BLOrderService>();
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web host environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable developer exception page, Swagger, and Swagger UI in development environment
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            // Configure routing, authorization, and endpoints
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
