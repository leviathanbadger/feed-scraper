using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using HostingHost = Microsoft.Extensions.Hosting.Host;

namespace Leviathanbadger.FeedScraper.Host.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return HostingHost.CreateDefaultBuilder(args)
                              .ConfigureWebHostDefaults(webBuilder =>
                              {
                                  webBuilder.UseStartup<Startup>();
                              });
        }
    }
}
