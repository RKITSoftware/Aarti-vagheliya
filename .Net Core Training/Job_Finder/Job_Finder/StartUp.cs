using Job_Finder.BusinessLogic;
using Job_Finder.Interface;
using Job_Finder.Middleware;
using Job_Finder.Model.POCO;
using Job_Finder.Services;
using Microsoft.OpenApi.Models;
using OfficeOpenXml;
using ServiceStack;

namespace Job_Finder
{
    /// <summary>
    /// Class responsible for configuring the application's services and request pipeline.
    /// </summary>
    public class StartUp
    {
        private readonly IConfiguration _configuration;

        public StartUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        public void ConfigureServices(IServiceCollection service)
        {
            // Add EPPlus license context setting
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set to your license context

            //service.AddControllers();
            service.AddControllers(config =>
            {
                //config.Filters.Add(new AuthenticationFilter());
                
            }).AddNewtonsoftJson();

            service.AddSwaggerGenNewtonsoftSupport();

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Finder API", Version = "v1" });

                //// Add security definition for Basic authentication
                //c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Scheme = "basic",
                //    Type = SecuritySchemeType.Http,
                //    Description = "Basic Authentication using the basic scheme"
                //});

                // Bearer Authentication
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                // Security Requirements
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });


            //string connectionString = _configuration.GetConnectionString("DefaultConnection");
            // service.AddScoped<DBContext>(provider => new DBContext(_configuration.GetConnectionString("DefaultConnection")));
            service.AddTransient<ICRUDService<CMP01>, CRUDImplementation<CMP01>>();
            service.AddTransient<ICRUDService<JOL01>, CRUDImplementation<JOL01>>();
            service.AddTransient<ICRUDService<JOS01>, CRUDImplementation<JOS01>>();
            service.AddTransient<ICRUDService<JOA01>, CRUDImplementation<JOA01>>();
            service.AddSingleton<IFileService, BLFileServiceHandler>();
           
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

            // Add CORS middleware
            app.UseCORSMiddleware();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
