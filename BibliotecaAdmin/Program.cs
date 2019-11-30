using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BibliotecaAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .UseUrls("http://localhost:57819")
               .Build();
    }

}
