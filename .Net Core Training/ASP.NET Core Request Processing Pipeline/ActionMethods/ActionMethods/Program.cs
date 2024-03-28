using Microsoft.AspNetCore;

namespace ActionMethods
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method responsible for starting the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Create and run the web host
            Builder(args).Run();
        }

        /// <summary>
        /// Builds the web host for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>The configured web host.</returns>
        public static IWebHost Builder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<StartUp>().Build();
    }
}