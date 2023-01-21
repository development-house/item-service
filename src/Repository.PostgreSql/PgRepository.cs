using Domain.Items;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Repository.PostgreSql;
public class PgRepository : IItemRepository
{
    private readonly IDbConnection _connection;
    public PgRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<Item> CreateItem(Item item, CancellationToken cancellationToken = default)
    {
        var entity = item.GetState();

        const string Sql = @"
            INSERT INTO [items]
            ([Name])
            VALUES
            (@Name);"
        ;

        return Item.Load(result);
    }
}
