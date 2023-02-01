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
            ammotype,
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
            @Ammotype,
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
            entity.Ammotype,
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
            UPDATE items SET
            name = COALESCE(NULLIF(@Name, ''), name),
            label = COALESCE(NULLIF(@Label, ''), label),
            type = COALESCE(NULLIF(@Type, ''), type),
            ammotype = COALESCE(NULLIF(@Ammotype, ''), ammotype),
            category = COALESCE(NULLIF(@Category, ''), category),
            model = COALESCE(NULLIF(@Model::integer, null::integer), model::integer)::integer,
            texture = COALESCE(NULLIF(@Texture::integer, null::integer), texture::integer)::integer,
            x = COALESCE(NULLIF(@X::integer, null::integer), x::integer)::integer,
            y = COALESCE(NULLIF(@Y::integer, null::integer), y::integer)::integer,
            weight = COALESCE(NULLIF(@Weight::integer, null::integer), weight::integer)::integer,
            decayrate = COALESCE(NULLIF(@Decayrate::integer, null::integer), decayrate::integer)::integer,
            image = COALESCE(NULLIF(@Image, ''), image),
            deg = COALESCE(NULLIF(@Deg::varchar(255), null::varchar(255)), deg::varchar(255))::Boolean,
            ""fullyDegrades"" = COALESCE(NULLIF(@FullyDegrades::varchar(255), null::varchar(255)), ""fullyDegrades""::varchar(255))::Boolean,
            ""nonStack"" = COALESCE(NULLIF(@NonStack::varchar(255), null::varchar(255)), ""fullyDegrades""::varchar(255))::Boolean,
            useable = COALESCE(NULLIF(@Useable::varchar(255), null::varchar(255)), useable::varchar(255))::Boolean,
            ""unique"" = COALESCE(NULLIF(@Unique::varchar(255), null::varchar(255)), ""unique""::varchar(255))::Boolean,
            ""shouldClose"" = COALESCE(NULLIF(@ShouldClose::varchar(255), null::varchar(255)), ""shouldClose""::varchar(255))::Boolean,
            ""useRemove"" = COALESCE(NULLIF(@UseRemove::varchar(255), null::varchar(255)), ""useRemove""::varchar(255))::Boolean,
            description = COALESCE(NULLIF(@Description, ''), description)
            WHERE id = @Id
            RETURNING *
            ;";

        var result = await _connection.QuerySingleOrDefaultAsync<ItemState>(new CommandDefinition(Sql, entity, cancellationToken: cancellationToken));

        return result.Id == Guid.Empty ? null : Item.Load(result);
    }
}