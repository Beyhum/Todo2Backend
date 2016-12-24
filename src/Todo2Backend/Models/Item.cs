using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo2Backend.Models
{
    // our main Model will be the Item class, which represents a single Item in a Todo List
    public class Item
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        // Entity Framework will take care of setting the ID of newly created Items. No need for a constructor which takes an id
        public Item(string title, string notes)
        {
            Title = title;
            Notes = notes;
        }

        // Entity Framework requires a parameterless constructor for all object used in the DbContext
        private Item()
        {

        }
    }
}
