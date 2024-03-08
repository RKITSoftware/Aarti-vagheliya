
using Dependancy_Injection.Data;
using Dependancy_Injection.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Dependancy_Injection
{
    /// <summary>
    /// Class for configuring application services and request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration settings.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services used by the application.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();

            // Add API explorer endpoints
            services.AddEndpointsApiExplorer();

            // Add Swagger generator service
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Country API", Version = "v1" });
            });

            // Get connection string from configuration
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
          
            // Add Entity Framework DbContext with MySQL provider
            services.AddDbContext<DBContextClass>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<ICountryService, CountryService>();
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Check if environment is development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Country API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

