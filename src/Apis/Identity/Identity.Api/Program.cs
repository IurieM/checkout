using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Identity.Api";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:5000")
                .UseStartup<Startup>();
    }
}
