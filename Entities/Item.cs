namespace Catalog.Entities;

// record has better support for immutable objects
//  - With expression support
//  - value based equality support
public record Item
{
    // init is for property values that we allow to set only on initialization 
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public decimal Price { get; init; }
    public DateTimeOffset CreatedDate  { get; init; }
}

