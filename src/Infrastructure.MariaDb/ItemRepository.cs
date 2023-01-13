using Dapper;
using Domain.Items;
using System.Data;

namespace Infrastructure.MariaDb;
public class ItemRepository : IItemRepository
{
    private readonly IDbConnection _connection;
    public ItemRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<Item> CreateItem(Item item, CancellationToken cancellationToken = default)
    {
        var entity = item.GetState();

        const string Sql = @"
            INSERT INTO [game].[items]
            ([Name])
            VALUES
            (@Name);";

        var result = await _connection.QuerySingleAsync<ItemState>(new CommandDefinition(Sql, entity), cancellationToken);

        return Item.Load(result);
    }
}
