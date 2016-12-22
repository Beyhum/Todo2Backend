using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo2Backend.Models;

namespace Todo2Backend.Controllers
{
    
    public class ItemsController : Controller
    {
        // GET api/items
        // This is a Route attribute, which is in charge of mapping a url path to a method in our controller
        // We call methods in a controller "Actions"
        [HttpGet("api/items")]
        public List<Item> Get()
        {

            List<Item> itemList = new List<Item> { new Item(1, "Some title", "Valuable notes"), new Item(2, "Get milk", "Make sure it isn't expired...")};
            return itemList;
        }

        // GET api/items/5
        // It's best to follow REST conventions and ommit the Action name when handling resources
        // Our HTTP Method should specify whether we GET or POST a resource
        // We can use HttpGet/HttpPost/... instead of Route in our attribute. The difference is that the Http attributes specify which HTTP method should be used
        [HttpGet("api/items/{id}")]
        // ASP.NET Core will automatically serialize our objects into JSON and return a response of content-type application/json with a string body representing our object as JSON
        public Item Get(int id)
        {
            return new Item(id, $"Item of Id = {id}", "Some random message body");
        }


        
    }
}
