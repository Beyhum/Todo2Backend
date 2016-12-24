using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Todo2Backend.Data;

namespace Todo2Backend
{
    public class Startup
    {
        // The constructor takes an IHostingEnvironment, which lets us determine whether our app is running in development or production
        // (i.e. being actively developped/tested on a local machine VS deployed live on our server and available for clients/users)  
        public Startup(IHostingEnvironment env)
        {
            // A ConfigurationBuilder allows us to read settings from multiple files and parse them all into one object (an IConfigurationRoot)
            // That way we can access all of our app's settings through an object during runtime
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            // Startup has a Configuration property (of type IConfigurationRoot)
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // ASP.NET Core is modular by design, and makes use of "services" that we can add to our app depending on our needs. This way we can keep our app fast and lightweight
        // We have to register the services that we plan on using. If we wanted to have an email or SMS service for example, we could get a package/library for that, then register it under this method
        public void ConfigureServices(IServiceCollection services)
        {
            // add EntityFrameworkCore with Sqlite as a service
            services.AddEntityFrameworkSqlite();

            // add ApplicationDbContext as a service.
            // We can add ApplicationDbContext in our Controller's constructor and ASP.NET will make sure to provide the proper instance of our DbContext when a Controller is created
            services.AddDbContext<ApplicationDbContext>();


            // Add framework services.
            // Even MVC is optional in ASP.NET Core. It is added by default as a package in our project.json (where all our dependencies are listed)
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // In here we define how we want our app to respond to HTTP requests that it receives
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // In short MVC (Model View Controller) is an architectural pattern which separates our app's logic from its presentation
            // We have a Controller than listens to user requests, selects relevant Models to use and returns data to the View which renders our data to the user
            // For more info on MVC, see https://docs.microsoft.com/en-us/aspnet/core/mvc/overview
            app.UseMvc();


        }
    }
}
