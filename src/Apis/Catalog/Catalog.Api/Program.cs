using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Catalog.Api";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:5001")
                .UseStartup<Startup>();
    }
}
