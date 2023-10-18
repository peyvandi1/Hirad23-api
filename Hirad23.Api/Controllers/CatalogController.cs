using Microsoft.AspNetCore.Mvc;
using Hirad23.Domain.Catalog;
using System.Collections.Generic;

namespace Hirad23.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>(){
                new Item(1, "Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item(2, "Shorts", "Ohio State shirt.", "Nike", 44.99m)
            };

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item(1, "Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item(3, "Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
