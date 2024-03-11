using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Token_Custom.Auth;
using Token_Custom.Filters;

namespace Token_Custom.Services
{
    public class AssignOAuth2SecurityRequirements : IOperationFilter
    {
        /// <summary>
        /// Apply OAuth2 security requirements to the operation based on the presence of BasicAuthentication or BearerAuthentication attributes.
        /// </summary>
        /// <param name="operation">The operation to apply security requirements.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="apiDescription">The API description.</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Check if the method has the BasicAuth attribute
            var basicAuthRequired = apiDescription.GetControllerAndActionAttributes<JwtAuthenticationFilter>().Any();

            // Check if the method has the BearerAuth attribute
            var bearerAuthRequired = apiDescription.GetControllerAndActionAttributes<BearerAuthentication>().Any();

            if (basicAuthRequired)
            {
                // Apply Basic Authentication
                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var basicAuth = new Dictionary<string, IEnumerable<string>>
                    {
                        { "basic", new string[] { } }
                    };

                operation.security.Add(basicAuth);
            }

            if (bearerAuthRequired)
            {
                // Apply Bearer Authentication
                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var bearerAuth = new Dictionary<string, IEnumerable<string>>
                    {
                        { "BearerToken", new string[] { } }
                    };

                operation.security.Add(bearerAuth);
            }
        }
    }
}