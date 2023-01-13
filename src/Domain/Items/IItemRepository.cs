namespace Domain.Items;
public interface IItemRepository
{
    Task<Item> CreateItem(Item item, CancellationToken cancellationToken = default);
}
