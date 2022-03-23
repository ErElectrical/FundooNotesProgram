using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes
{
    /// <summary>
    /// Adding the web host Builder 
    /// configure startup class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method Entry point
        /// compile the CreateHostBuilder method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }


        /// <summary>
        /// Method do two things
        /// Adding the web host builder
        /// configuring the startup class
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
          
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
