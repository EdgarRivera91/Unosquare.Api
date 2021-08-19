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
        private readonly I_ItemManager<Item> _itemsManager;

        public ItemsController(I_ItemManager<Item> itemManager)
        {
            _itemsManager = itemManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Item> employees = _itemsManager.GetAll();
            return Ok(employees);
        }

        // GET: api/Item/5
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
            return CreatedAtRoute(
                  "Get",
                  new { Id = item.ItemID },
                  item);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }
            Item employeeToUpdate = _itemsManager.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Item record couldn't be found.");
            }
            _itemsManager.Update(employeeToUpdate, item);
            return NoContent();
        }

        // DELETE: api/Item/5
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
