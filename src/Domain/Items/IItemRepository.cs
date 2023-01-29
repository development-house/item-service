namespace Domain.Items;
public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItemsAsync(string? name = default, CancellationToken cancellationToken = default);
    Task<Item?> GetItemAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Item> CreateItem(Item item, CancellationToken cancellationToken = default);
}
