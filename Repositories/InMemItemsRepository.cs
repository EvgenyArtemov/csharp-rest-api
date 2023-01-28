using Catalog.Entities;

namespace Catalog.Repositories;

class InMemItemsRepository
{
    private readonly List<Item> _items = new List<Item>()
    {
        new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow },
    };

    public IEnumerable<Item> GetItems()
    {
        return _items;
    }

    public Item GetItem(Guid id)
    {
        return _items.SingleOrDefault(item => item.Id == id);
    }
}
