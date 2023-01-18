namespace Domain;
public interface IItemContext
{
    Task<string?> GetItem();
}
