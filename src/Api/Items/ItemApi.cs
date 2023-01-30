namespace Api.Items;
public static class ItemApi
{
    public static IEndpointRouteBuilder MapItemApi(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("/item")
            .MapPost("/", CreateItem.Create);
        builder.MapGroup("/item")
            .MapGet("/", GetItems.Search);
        builder.MapGroup("/item")
            .MapGet("/{id}", GetItems.GetItem);
        builder.MapGroup("/item")
            .MapPatch("/", UpdateItem.Update);

        return builder;
    }
}