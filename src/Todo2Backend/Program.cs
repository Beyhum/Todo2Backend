using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Todo2Backend
{
    // ASP.NET Core apps are just Console Applications at the end of the day
    // The Program class' Main method is called when launched
    // In our Main method, we create a Web Host which listens to HTTP requests directed at our server and passes them over to our app
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                // Kestrel is a cross-platform web server
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                // If we want to run our app on a Windows server, we can use IIS (a web server with advanced features for Windows)
                .UseIISIntegration()
                // Set the startup class to use. It will be in charge of configuring our app
                // In this case we have a class called "Startup" (in Startup.cs) which we pass as our startup class
                .UseStartup<Startup>()
                .Build();

            // Run our web host, which allows our app to listen to requests
            host.Run();
        }
    }
}
