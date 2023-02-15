using Catalog.Entities;

namespace Catalog.Repositories;

internal interface  IInMemItemsRepository
{
    IEnumerable<Item> GetItems();
    Item GetItem(Guid id);
}