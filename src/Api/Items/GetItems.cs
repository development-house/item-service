using Application.Items.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Items;

public static class GetItems
{
    public static async Task<ActionResult<IEnumerable<ItemResponse>>> Search(
                                                    IMediator mediator,
                                                    string? name = default,
                                                    CancellationToken cancellationToken = default)
    {
        var query = new GetItemsQuery(name);
        var items = await mediator.Send(query, cancellationToken);
        return items.Select(ItemResponse.Create).ToList();
    }

    public static async Task<ActionResult<ItemResponse>> GetItem(
                                         IMediator mediator,
                                         Guid id,
                                         CancellationToken cancellationToken = default)
    {
        var query = new GetItemQuery(id);
        var item = await mediator.Send(query, cancellationToken);
        var response = ItemResponse.Create(item);
        return (response);
    }
}