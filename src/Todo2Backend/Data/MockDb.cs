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
               
            };
        }
    }
}
