using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo2Backend.Models;

// To use an actual database, we can use Entity Framework: A framework which maps objects in our C# code to tables in our Database. More info: https://docs.microsoft.com/en-us/ef/core/index
// Entity Framework supports multiple Database providers such as Sql Server, MySQL, Sqlite, PostgreSQL
// We Create a class inheriting from DbContext, which will be in charge of interacting with our database and mapping queries to objects

// We have to register EntityFrameworkCore and our ApplicationDbContext as services in our Startup class
// We then swap our MockDb with an ApplicationDbContext

// To actually create our Database, we have to use the Entity Framework Tooling (we added a package for EF Tools in our Project.json).
// If you have visual studio, open the Package Manager Console (Tools -> Nuget Package Manager)
// Otherwise open the command line/terminal in your project's root directory (in this case inside the Todo2Backend folder)

// EF uses "Migrations" to incrementally update the database when we make changes to it
// To create a migration, we use "Add-Migration {migration_name}" using Package Manager. If on command line, use "dotnet ef migrations add {migration_name}"
// Calling "Add-Migration InitialCreate" Will create a Migrations folder, with an InitialCreate file containing all the changes to apply on our database and a Snapshot file which shows our Database's current state
// We then call "Update-Database" using the Package Manager or "dotnet ef database update" using the command line
// Update-Database will update our database to the latest migration (in this case InitialCreate)
// Since Sqlite only creates a file to store our database, we will have a "MyItemDatabase.db" file found in "Todo2Backend\src\Todo2Backend\bin\Debug\netcoreapp1.0"
namespace Todo2Backend.Data
{
    public class ApplicationDbContext : DbContext
    {

        // add a DbSet<Item> property. Each DbSet will map to a table in our Database
        public DbSet<Item> Items { get; set; }

        // 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We have to specify that EntityFramework will connect to a Sqlite database. Sqlite is a lightweight DB which simply creates a single file that stores our entire database
            // We could get another Database provider like Sql Server or MySQL and swap out our Sqlite database
            // UseSqlite takes a connection string, which is just the filename of our Db. If we were using a proper database server like Sql Server, the connection string would specify the database server's name and password among other things
            // Normally, you should never have your connection strings hardcoded into your code. However in this case our connection string only includes the filename of our demo Sqlite DB
            // You use Environment Variables and User Secrets to manage sensitive connection strings. See https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
            optionsBuilder.UseSqlite("Filename=MyItemDatabase.db");
        }
    }
}
