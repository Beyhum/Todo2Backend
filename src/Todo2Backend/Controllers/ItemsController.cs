using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo2Backend.Models;
using Todo2Backend.Data;

namespace Todo2Backend.Controllers
{

    // Instead of setting the entire route path for each action in our controller, we can set a base route path for all actions in a controller by using a route tag above the class name
    [Route("api/[controller]")] // by specifying "[controller]" instead of "items", our route will automatically get the name of our class (without the -Controller suffix)
    public class ItemsController : Controller
    {

        // add a private MockDb field
        private MockDb _mockDb = MockDb.Instance;

        // GET api/items
        [HttpGet]
        public List<Item> Get()
        {
            // return all items in our MockDb
            List<Item> itemList = _mockDb.Items;
            return itemList;
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            // return the item of specified id or return null
            Item queriedItem = _mockDb.Items.FirstOrDefault(item => item.Id == id);
            return queriedItem;
        }


        
    }
}
