using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Basket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Basket.Api";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:5002")
                .UseStartup<Startup>();
    }
}
