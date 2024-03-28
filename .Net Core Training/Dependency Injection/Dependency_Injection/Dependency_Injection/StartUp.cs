using Dependency_Injection.Interface;
using Dependency_Injection.Service;

namespace Dependency_Injection
{
    /// <summary>
    /// This is configure class of the application.
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            //Add controller services
            services.AddControllers();

            services.AddSingleton<IDancerService, DancerService>();

            services.AddSingleton<ISingleton, ServiceLifeTime>();
            services.AddTransient<ITransient, ServiceLifeTime>();
            services.AddScoped<IScoped, ServiceLifeTime>();

            // Configure Swagger for Basic Authentication
            services.AddSwaggerGen();
         
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

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
