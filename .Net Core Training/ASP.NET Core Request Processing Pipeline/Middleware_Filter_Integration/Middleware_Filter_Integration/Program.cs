using Microsoft.AspNetCore;
using Middleware_Filter_Integration;

/// <summary>
/// main class of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// This method initializes and runs the web host, starting the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        Builder(args).Run();
    }

    /// <summary>
    /// Builds the web host for the application.
    /// This method configures the web host using default settings and specifies the Startup class.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>The configured web host.</returns>
    public static IWebHost Builder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();
}
