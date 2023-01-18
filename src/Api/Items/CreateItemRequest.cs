using Application.Items.Commands;

namespace Api.Items;
public record CreateItemRequest(
        string Name,
        string Label,
        string Type,
        string Category,
        int Model,
        int Texture,
        int X,
        int Y,
        int Weight,
        int Decayrate,
        string Image,
        bool Deg,
        bool FullyDegrades,
        bool NonStack,
        bool Useable,
        bool Unique,
        bool ShouldClose,
        bool UseRemove,
        string Description)
{
    public CreateItemCommand ToCommand()
    {
        return new CreateItemCommand(
            Name,
            Label,
            Type,
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