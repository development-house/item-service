using Dapper;
using Domain.Items;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace Repository.PostgreSql;
public class PgRepository : IItemRepository
{
    private readonly IDbConnection _connection;
    public PgRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(string? name = default, CancellationToken cancellationToken = default)
    {
        var limit = 20;
        var filters = new Dictionary<string, string?>
            {
                { "name", name }
            }.Where(filter => !string.IsNullOrEmpty(filter.Value))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        var filterString = filters.Any()
            ? $@"WHERE {string.Join(" AND ",
                filters.Select(filter => $"{filter.Key} ~ '{filter.Value}'")
            )}"
            : string.Empty;

        var sql = @$"
            SELECT distinct *
	        FROM public.items
            {filterString} 
	        ORDER BY name desc
	        fetch first 10 rows only";

        var parameters =
            new DynamicParameters(filters.ToDictionary(kvp => kvp.Key, kvp =>
            {
                var prefixSearch = !kvp.Value!.Contains(' ') ? "" : string.Empty;
                return $"\"{kvp.Value}{prefixSearch}\"" as object;
            }));
        parameters.Add(nameof(limit), limit, DbType.Int32);

        var result = await _connection.QueryAsync<ItemState>(
        new CommandDefinition(
            sql,
            cancellationToken: cancellationToken)
        );

        return result.Select(Item.Load).ToList();
    }

    public async Task<Item?> GetItemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var filters = new Dictionary<string, Guid>
            {
                { "id", id }
            }
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        var filterString = filters.Any()
            ? $@"WHERE {string.Join(" AND ",
                filters.Select(filter => $"{filter.Key} = '{filter.Value}'")
            )}"
            : string.Empty;

        var sql = @$"
            SELECT distinct *
	        FROM public.items
            {filterString}";

        var result = await _connection.QuerySingleOrDefaultAsync<ItemState>(
            new CommandDefinition(
                sql,
                cancellationToken: cancellationToken)
            );

        return result.Id == Guid.Empty ? null : Item.Load(result);
    }

    public async Task<Item> CreateItemAsync(Item item, CancellationToken cancellationToken = default)
    {
        var entity = item.GetState();

        const string Sql = @"
            INSERT INTO public.items
            (id,
            name,
            label,
            type,
            category,
            model,
            texture,
            x,
            y,
            weight,
            decayrate,
            image,
            deg,
            ""fullyDegrades"",
            ""nonStack"",
            useable,
            ""unique"",
            ""shouldClose"",
            ""useRemove"",
            description)
	        VALUES
            (@Id,
            @Name,
            @Label,
            @Type,
            @Category,
            @Model,
            @Texture,
            @X,
            @Y,
            @Weight,
            @Decayrate,
            @Image,
            @Deg,
            @FullyDegrades,
            @NonStack,
            @Useable,
            @Unique,
            @ShouldClose,
            @UseRemove,
            @Description)
            RETURNING
            *
            ;";

        var result = await _connection.QuerySingleOrDefaultAsync<ItemState>(new CommandDefinition(Sql,
        new
        {
            entity.Id,
            entity.Name,
            entity.Label,
            entity.Type,
            entity.Category,
            entity.Model,
            entity.Texture,
            entity.X,
            entity.Y,
            entity.Weight,
            entity.Decayrate,
            entity.Image,
            entity.Deg,
            entity.FullyDegrades,
            entity.NonStack,
            entity.Useable,
            entity.Unique,
            entity.ShouldClose,
            entity.UseRemove,
            entity.Description
        }, cancellationToken: cancellationToken));

        return Item.Load(result);
    }

    public async Task<Item> UpdateItemAsync(Item item, CancellationToken cancellationToken = default)
    {
        var entity = item.GetState();

        const string Sql = @"
            ;";

        var result = await _connection.QuerySingleOrDefaultAsync<ItemState>(new CommandDefinition(Sql, entity, cancellationToken: cancellationToken));

        return result.Id == Guid.Empty ? null : Item.Load(result);
    }
}
