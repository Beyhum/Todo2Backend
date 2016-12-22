using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo2Backend.Models;

namespace Todo2Backend.Data
{

    // the MockDb class will represent our database before we actually use one
    public class MockDb
    {
        // The Items property will represent our Item table
        public List<Item> Items;

        // We must have 1 instance of our Mock Database across our application, so we use the singleton pattern
        public static MockDb Instance { get; } = new MockDb();

        private MockDb()
        {
            Items = new List<Item>
            {
                new Item(1, "Get a secret santa gift", "Make sure that it's gift-wrapped"),
                new Item(2, "Buy a plane ticket before Sunday", "Try to find a deal for 2"),
                new Item(3, "Check up on course registration", "Get there before 10:00 am, offices close early")
            };
        }
    }
}
