using FiltersApi;
using Microsoft.AspNetCore;

internal class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        Builder(args).Run();
    }

    /// <summary>
    /// Builds the web host for the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>The configured web host.</returns>
    public static IWebHost Builder(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
}
