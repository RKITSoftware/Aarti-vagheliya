namespace Routing
{
    /// <summary>
    /// The entry point class for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Build and run the host
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the host builder for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>The configured host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Use the Startup class for configuring the application
                    webBuilder.UseStartup<Startup>();
                });
    }
}