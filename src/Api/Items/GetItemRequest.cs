using Application.Items.Commands;

namespace Api.Items;
public record GetItemRequest(
        Guid Id)
{
    public GetItemQuery ToQuery()
    {
        return new GetItemQuery(
            Id
        );
    }
}