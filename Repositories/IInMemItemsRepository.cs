using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog.Repositories;

public interface  IInMemItemsRepository
{
    IEnumerable<Item> GetItems();
    Item GetItem(Guid id);
    void CreateItem(Item item);
}