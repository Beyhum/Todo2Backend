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


        // POST api/items
        [HttpPost] // we can't test POST requests using a browser's address bar, we need to use a tool like Postman to define what HTTP method we want to use. See https://www.getpostman.com/
        public IActionResult Post([FromBody]ItemPostDto itemToPost) // The [FromBody] attribute specifies that the parameter is found in the request body
        {
            // Controller has a property called ModelState. ModelState checks all the parameters that our called action requires and sees if they are valid
            // In our ItemPostDto, we set the Title property as Required with a min length of 2. If the client's request doesn't contain a Title with these conditions,
            // then the ModelState.IsValid property will be false
            bool isValidPost = ModelState.IsValid;

            if (!isValidPost)
            {
                // we return a BadRequest (400 response) with the ModelState in the response body. The ModelState object will represent the list of errors the client made
                // e.g. The request body was missing a "Title" property
                return BadRequest(ModelState);
            }


            // copy the Title and Notes properties from the ItemPostDto to the actual Item object that will be created and stored in our database
            // we define the ID for this new Item as the length of our List of Items + 1
            Item postedItem = new Item(id: _mockDb.Items.Count + 1, title: itemToPost.Title, notes: itemToPost.Notes);

            // add the new item to our DB
            _mockDb.Items.Add(postedItem);

            // CreatedAtAction() gives a 201 response (CreatedAt) with a response header named "Location" which defines the URL at which we can find the newly created Item
            // 1st parameter is the Action name (name of method in this controller which returns the Item), 2nd is route values (parameters that the method takes), 3rd is the created Item itself
            return CreatedAtAction("Get", new { id = postedItem.Id }, postedItem);
        }




    }
}
