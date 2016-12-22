using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Todo2Backend.Controllers
{
    
    public class ValuesController : Controller
    {
        // GET api/values
        // This is a Route attribute, which is in charge of mapping a url path to a method in our controller
        // We call methods in a controller "Actions"
        [HttpGet("api/values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // It's best to follow REST conventions and ommit the Action name when handling resources
        // Our HTTP Method should specify whether we GET or POST a resource
        // We can use HttpGet/HttpPost/... instead of Route in our attribute. The difference is that the Http attributes specify which HTTP method should be used
        [HttpGet("api/values/{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }


        
    }
}
