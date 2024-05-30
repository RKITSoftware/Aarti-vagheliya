using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Web.Http;

namespace Job_Finder.Filters
{
    /// <summary>
    /// Operation filter for adding security requirements to Swagger documentation.
    /// </summary>
    public class AuthHeaderOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the security requirements to the specified operation.
        /// </summary>
        /// <param name="operation">The OpenApiOperation to which security requirements will be applied.</param>
        /// <param name="context">The OperationFilterContext containing information about the operation.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Retrieve all Authorize attributes applied to the method or its declaring type
            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                    .Union(context.MethodInfo.GetCustomAttributes(true))
                                    .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                // Apply Bearer token security to endpoints with Authorize attribute
                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    }
                };
            }

            // Retrieve all AllowAnonymous attributes applied to the method
            var allowAnonymousAttributes = context.MethodInfo.GetCustomAttributes(true)
                                            .OfType<AllowAnonymousAttribute>();

            // If any AllowAnonymous attributes are found, clear any security requirements from the operation
            if (allowAnonymousAttributes.Any())
            {
                operation.Security.Clear();
            }

            // If the method name is "Login", apply Basic authentication security to the operation
            else if (context.MethodInfo.Name.Equals("Login", StringComparison.OrdinalIgnoreCase))
            {
                // Apply Basic authentication security to the login endpoint
                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
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
                }
            };
            }
        }
    }
}
