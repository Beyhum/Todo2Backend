using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo2Backend.Models
{
    // When we ask the client to POST an Item, they shouldn't specify an ID. Our Backend should decide the ID of newly created Items
    // We will be using a DTO (Data Transfer Object) which represents a posted item without the Id property
    // We use DTOs when there are properties that we want to hide from the client 
    public class ItemPostDto
    {

        public string Title { get; set; }

        public string Notes { get; set; }
    }
}
