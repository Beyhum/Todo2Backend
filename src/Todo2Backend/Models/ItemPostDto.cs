using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo2Backend.Models
{
    // When we ask the client to POST an Item, they shouldn't specify an ID. Our Backend should decide the ID of newly created Items
    // We will be using a DTO (Data Transfer Object) which represents a posted item without the Id property
    // We use DTOs when there are properties that we want to hide from the client 
    public class ItemPostDto
    {
        // We can add attributes above properties to create constraints around our objects
        // For example if we require the client to always include a Title, we use the [Required] attribute
        // Make sure to import the "System.ComponentModel.DataAnnotations" namespace

        [Required]
        [StringLength(50, MinimumLength = 2)] // specifies that the max length of title is 50, minimum is 2
        public string Title { get; set; }

        public string Notes { get; set; }
    }
}
