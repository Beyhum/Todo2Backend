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
        // So in this case we have the format api/{controller}/{action} which is api/Values/Get
        // If we go to baseurl/api/values/get then this action will get called, which will simply return an array or strings
        [Route("api/values/Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        
    }
}
