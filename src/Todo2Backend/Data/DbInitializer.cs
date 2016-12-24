using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo2Backend.Models;

namespace Todo2Backend.Data
{
    // Our DbInitializer will make sure that our database is initialized and up to date whenever our application runs
    // We will call DbInitializer.Initialize in our Startup's Configure() Method
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Equivalent to calling "Update-Database" or "dotnet ef database update" through the Entity Framework Tool
            context.Database.Migrate();

            if (!context.Items.Any())
            {
                var itemsToAdd = new List<Item>
            {
                new Item("Hi", "Notes notes 1" ),
                new Item("Bye", "Notes notes 2"),
                new Item("Why", "Notes notes 3")
            };
                context.Items.AddRange(itemsToAdd);

                context.SaveChanges();
            }
        }
    }
}
