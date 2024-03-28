namespace ActionMethods
{
    /// <summary>
    /// Class responsible for configuring the application's services and request pipeline.
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
        }

        /// <summary>
        /// Configures the request pipeline for the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
