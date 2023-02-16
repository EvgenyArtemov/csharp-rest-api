using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog.Controllers;

// request to /items
[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
     private readonly IInMemItemsRepository repository; 

     public ItemsController(IInMemItemsRepository repository)
     {
          this.repository = repository;
     }

     // we define this attribute to react on GET request
     [HttpGet]
     public IEnumerable<ItemDto> GetItems()
     {
          var items = repository.GetItems().Select(item => item.AsDto());
          return items;
     }

     [HttpGet("{id}")]
     public ActionResult<ItemDto> GetItem(Guid id)
     {
          var item = repository.GetItem(id);
          if (item is null)
          {
               return NotFound();
          }
          return item.AsDto(); 
     }

     [HttpPost]
     public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
     {
          Item item = new()
          {
               Id = Guid.NewGuid(),
               Name = itemDto.Name,
               Price = itemDto.Price,
               CreatedDate = DateTimeOffset.UtcNow
          };
          repository.CreateItem(item);
          return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
     }

     [HttpPut("{id}")]
     public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
     {
          var existingItem = repository.GetItem(id);
          if (existingItem is null)
          {
               return NotFound();
          }

          Item updatedItem = existingItem with
          {
               Name = itemDto.Name,
               Price = itemDto.Price
          };
          
          repository.UpdateItem(updatedItem);
          return NoContent(); 
     }
}