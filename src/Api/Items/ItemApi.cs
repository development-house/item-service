namespace Api.Items;
public static class ItemApi
{
    public static IEndpointRouteBuilder MapItemApi(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("/item")
            .MapPost("/", CreateItem.Create);
        return builder;
    }
}