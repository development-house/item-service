namespace Domain.Items;
public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItemsAsync(string? name = default, CancellationToken cancellationToken = default);
    Task<Item?> GetItemAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Item> CreateItemAsync(Item item, CancellationToken cancellationToken = default);
    Task<Item> UpdateItemAsync(Item item, CancellationToken cancellationToken = default);
}
