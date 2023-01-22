using Application.Items.Commands;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Api.Items;
public record CreateItemRequest(
        Guid Id)
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