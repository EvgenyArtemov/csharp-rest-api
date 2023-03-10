namespace Catalog.Dtos;

public record ItemDto
{
    // init is for property values that we allow to set only on initialization 
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public decimal Price { get; init; }
    public DateTimeOffset CreatedDate  { get; init; }
}