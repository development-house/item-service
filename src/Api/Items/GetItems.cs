using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Items;

public static class GetItems
{
    public static async Task<<ItemResponse>, ProblemHttpResult>> ById(
                                             CreateItemRequest request,
                                             IMediator mediator,
                                             CancellationToken cancellationToken = default)
    {
        var command = request.ToRequest();
        var item = await mediator.Send(command, cancellationToken);
        var response = ItemResponse.Create(item);
        return TypedResults.Created($"/item/{request.Name}", response);
    }

    public static async Task<Results<Created<ItemResponse>, ProblemHttpResult>> All(
                                         CreateItemRequest request,
                                         IMediator mediator,
                                         CancellationToken cancellationToken = default)
    {
        var command = request.ToCommand();
        var item = await mediator.Send(command, cancellationToken);
        var response = ItemResponse.Create(item);
        return TypedResults.Created($"/item/{request.Name}", response);
    }
}
