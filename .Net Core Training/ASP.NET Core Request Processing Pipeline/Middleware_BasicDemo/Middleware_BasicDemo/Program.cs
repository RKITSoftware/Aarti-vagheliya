using Middleware_BasicDemo;

internal class Program
{

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
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