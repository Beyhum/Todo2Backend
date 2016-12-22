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
        // Return IActionResult instead of Lists/Items. IActionResult is an interface which represents any result that an action can return
        // i.e. an html page, JSON, a file, etc...
        // Using IActionResult lets us wrap the objects we return with HTTP Response messages that we define (Not Found, Bad Request, Success, etc...)
        public IActionResult Get()
        {
            // return all items in our MockDb
            List<Item> itemList = _mockDb.Items;
            // Ok() is a method in Controller which takes an object and returns a 200 response code with the object in the response body
            return Ok(itemList);
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // return the item of specified id or return null
            Item queriedItem = _mockDb.Items.FirstOrDefault(item => item.Id == id);

            if(queriedItem == null)
            {
                // If we couldn't find an Item with the specified Id, we should use NotFound() which returns a 404 response
                return NotFound();
            }
            return Ok(queriedItem);
        }




        
    }
}
