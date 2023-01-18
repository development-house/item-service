﻿using Dapper;
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
            INSERT INTO [items]
            ([id]
            [name],
            [label],
            [type],
            [category],
            [model],
            [texture],
            [x],
            [y],
            [weight],
            [decayrate],
            [image],
            [deg],
            [fullyDegrades],
            [nonStack],
            [useable],
            [unique],
            [shouldClose],
            [useRemove],
            [description])
            OUTPUT
            INSERTED.*  
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
            @Description);";

        var result = await _connection.QuerySingleOrDefaultAsync<ItemState>(new CommandDefinition(Sql, 
        new {
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
}
