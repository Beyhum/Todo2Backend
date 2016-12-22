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

        public Item(int id, string title, string notes)
        {
            Id = id;
            Title = title;
            Notes = notes;
        }
    }
}
