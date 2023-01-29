using Domain.Items;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Items;

public class UpdateItem
{
    public static async Task<Ok<ItemResponse>> Update (
    UpdateItemRequest request,
    IMediator mediator,
    CancellationToken cancellationToken = default)
    {
        var command = request.ToUpdateItemCommand();
        var item = await mediator.Send(command, cancellationToken);
        var response = ItemResponse.Create(item);
        return TypedResults.Ok(response);
    }
}
