using Domain.Items;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Items;
public static class CreateItem
{
    public static async Task<Results<Created<ItemResponse>, ProblemHttpResult>> Create(
    CreateItemRequest request,
    IMediator mediator,
    CancellationToken cancellationToken = default)
    {
        var command = request.ToCreateItemCommand();
        var item = await mediator.Send(command, cancellationToken);
        var response = ItemResponse.Create(item);
        return TypedResults.Created($"/item/{request.Name}", response);
    }
}
