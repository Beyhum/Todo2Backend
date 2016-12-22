using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo2Backend.Models;

namespace Todo2Backend.Controllers
{
    // Instead of setting the entire route path for each action in our controller, we can set a base route path for all actions in a controller by using a route tag above the class name
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        // GET api/items
        [HttpGet] // equivalent to [HttpGet("")]. Since we defined a base route for our controller "api/Items", we call this action through baseurl/api/Items
        public List<Item> Get()
        {
            List<Item> itemList = new List<Item> { new Item(1, "Some title", "Valuable notes"), new Item(2, "Get milk", "Make sure it isn't expired...")};
            return itemList;
        }

        // GET api/items/5
        [HttpGet("{id}")] // Since we defined a base route for our controller "api/Items", we call this action through baseurl/api/Items/id
        // ASP.NET Core will automatically serialize our objects into JSON and return a response of content-type application/json with a body representing our object
        public Item Get(int id)
        {
            return new Item(id, $"Item of Id = {id}", "Some random message body");
        }


        
    }
}
