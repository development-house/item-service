using Domain.Items;
using System.Data;

namespace Infrastructure.PostgreSql;
public class PgRepository
{
    private readonly IDbConnection _connection;
    public PgRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<string> CreateItem(Item item, CancellationToken cancellationToken = default)
    {
        var entity = item.GetState();

        const string Sql = @"
            INSERT INTO [items]
            ([Name])
            VALUES
            (@Name);";

        return "success";
    }
}
