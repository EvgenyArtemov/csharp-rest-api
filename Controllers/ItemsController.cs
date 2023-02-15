using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
 
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
     public IEnumerable<Item> GetItems()
     {
          var items = repository.GetItems();
          return items;
     }

     [HttpGet("{id}")]
     public ActionResult<Item> GetItem(Guid id)
     {
          var item = repository.GetItem(id);
          if (item is null)
          {
               return NotFound();
          }
          return item; 
     } 
}