using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unosquare.Services.Contracts;
using Unosquare.Data.Models;

namespace Unosquare.API.Controllers
{
    [Route("api/items")]

    [ApiController]
    public class ItemsController : ControllerBase
    {
        //TODO: No exception handling on any method
        private readonly I_ItemManager<Item> _itemsManager;

        public ItemsController(I_ItemManager<Item> itemManager)
        {
            _itemsManager = itemManager;
        }

        // GET: api/Item
        [HttpGet]
        public IActionResult Get()
        {
            //TODO: In the Getby Id you are following the good practice but not here, why? 
            IEnumerable<Item> items = _itemsManager.GetAll();
            return Ok(items);
        }

        // GET: api/Item/{item}
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Item item = _itemsManager.Get(id);
            if (item == null)
            {
                return NotFound("The Item couldn't be found.");
            }
            return Ok(item);
        }

        // POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }
            _itemsManager.Add(item);
            //TODO: Why the route name is GET  ?
            //TODO: Please take a look at the created at route usage https://stackoverflow.com/questions/25045604/can-anyone-explain-createdatroute-to-me/25110700 Maybe we can use return OK? 
            //TODO: Take a look at the Rfc standard for the post https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html#sec9.5

            return CreatedAtRoute(
                  "Get",
                  new { Id = item.ItemID },
                  item);
        }

        // (Update) PUT: api/Item/{item}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Item item)
        {
            //TODO: you could move all the logic (IF, else,) to the service instead of the controller
            if (item == null)
            {
                return BadRequest("Item is null.");
            }
            Item itemToUpdate = _itemsManager.Get(id);
            if (itemToUpdate == null)
            {
                return NotFound("The Item record couldn't be found.");
            }
            _itemsManager.Update(itemToUpdate, item);
            return NoContent(); //TODO: its better to send an ok
        }

        // DELETE: api/Item/{item}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Item item = _itemsManager.Get(id);
            if (item == null)
            {
                return NotFound("The item record couldn't be found.");
            }
            _itemsManager.Delete(item);
            return NoContent();
        }
    }
}
