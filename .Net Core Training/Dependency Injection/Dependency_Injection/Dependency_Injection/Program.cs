using Microsoft.AspNetCore;

namespace Dependency_Injection
{
    /// <summary>
    /// This class is entry point of the application.
    /// </summary>
    public class Program
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
            WebHost.CreateDefaultBuilder(args).UseStartup<StartUp>().Build();
    }
}