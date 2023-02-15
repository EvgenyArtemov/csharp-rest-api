using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Dtos;

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
}