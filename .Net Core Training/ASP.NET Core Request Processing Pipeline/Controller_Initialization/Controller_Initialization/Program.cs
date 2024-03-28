namespace Controller_Initialization
{
    /// <summary>
    /// This class contains the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to start the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
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
                    // Uses the Startup class to configure the application.
                    webBuilder.UseStartup<StartUp>();
                });
    }
}