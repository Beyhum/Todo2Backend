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
        // If we go to baseurl/api/values/get then this action will get called, which will simply return an array or strings
        [Route("api/values/Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // MVC will map any url under the form api/values/Get/{id} to this method
        // it will assign any int that is written after "api/values/Get/" to our id parameter because of the "{id}" route template 
        // Names specified in {} will be automatically matched to parameters with the same name in the parameter list
        [Route("api/values/Get/{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }


        
    }
}
