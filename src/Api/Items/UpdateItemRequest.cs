using Application.Items.Commands;

namespace Api.Items;

public record UpdateItemRequest(
        Guid Id,
        string? Name,
        string? Label,
        string? Type,
        string? Ammotype,
        string? Category,
        int? Model,
        int? Texture,
        int? X,
        int? Y,
        int? Weight,
        int? Decayrate,
        string? Image,
        bool? Deg,
        bool? FullyDegrades,
        bool? NonStack,
        bool? Useable,
        bool? Unique,
        bool? ShouldClose,
        bool? UseRemove,
        string? Description)
{
    public UpdateItemCommand ToUpdateItemCommand()
    {
        return new UpdateItemCommand(
            Id,
            Name,
            Label,
            Type,
            Ammotype,
            Category,
            Model,
            Texture,
            X,
            Y,
            Weight,
            Decayrate,
            Image,
            Deg,
            FullyDegrades,
            NonStack,
            Useable,
            Unique,
            ShouldClose,
            UseRemove,
            Description
        );
    }
}
