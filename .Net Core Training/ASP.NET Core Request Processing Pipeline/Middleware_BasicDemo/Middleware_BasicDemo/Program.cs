using Middleware_BasicDemo;

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method which acts as the entry point of the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        // Create a new web application builder
        var builder = WebApplication.CreateBuilder(args);

        // Build the web application
        var app = builder.Build();

        // Map the specified middleware extension method to the "/UseExtension" request path
        app.Map("/UseExtension", MiddlewareExtension.UseExtension);

        // Add the CustomMiddleware to the application's request processing pipeline
        app.UseMiddleware<CustomMiddleware>();

        // Add a terminal middleware to the pipeline that writes "END" to the response
        // This middleware will execute if no other middleware handles the request
        app.Run(async context => await context.Response.WriteAsync("\nEND"));

        app.Run();

       
    }

}