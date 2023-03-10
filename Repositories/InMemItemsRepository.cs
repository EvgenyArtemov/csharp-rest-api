using Catalog.Entities;
using Catalog.Dtos;

namespace Catalog.Repositories;

 class InMemItemsRepository : IInMemItemsRepository
{
    private readonly List<Item> _items = new()
    {
        new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
    };

    public IEnumerable<Item> GetItems()
    {
        return _items;
    }

    public Item GetItem(Guid id)
    {
        return _items.SingleOrDefault(item => item.Id == id);
    }

    public void CreateItem(Item item)
    {
         _items.Add(item);
    }

    public void UpdateItem(Item item)
    {
        var index = _items.FindIndex(exItem => exItem.Id == item.Id);
        _items[index] = item;
    }

    public void DeleteItem(Guid id)
    {
        var index = _items.FindIndex(exItem => exItem.Id == id); 
        _items.RemoveAt(index);
    }
}



