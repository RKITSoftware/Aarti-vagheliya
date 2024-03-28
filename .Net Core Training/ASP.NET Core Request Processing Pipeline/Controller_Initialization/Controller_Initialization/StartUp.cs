namespace Controller_Initialization
{
    /// <summary>
    /// This class is the entry point of the application
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="services">The instance of the IServiceCollection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        /// <summary>
        /// Configures the application's request pipeline.
        /// </summary>
        /// <param name="app">The instance of the IApplicationBuilder.</param>
        /// <param name="env">The instance of the IWebHostEnvironment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Routing Middleware
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
