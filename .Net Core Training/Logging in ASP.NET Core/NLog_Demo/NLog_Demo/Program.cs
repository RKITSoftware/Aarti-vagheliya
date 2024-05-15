using Microsoft.AspNetCore;

namespace NLog_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Builder(args).Run();
        }

        public static IWebHost Builder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<StartUp>().Build();
    }
}