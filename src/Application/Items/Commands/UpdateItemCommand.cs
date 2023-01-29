using MediatR;
using Domain.Items;
namespace Application.Items.Commands;
public record UpdateItemCommand(
        Guid id,
        string? name,
        string? label,
        string? type,
        string? category,
        int? model,
        int? texture,
        int? x,
        int? y,
        int? weight,
        int? decayrate,
        string? image,
        bool? deg,
        bool? fullyDegrades,
        bool? nonStack,
        bool? useable,
        bool? unique,
        bool? shouldClose,
        bool? useRemove,
        string? description
): IRequest<Item>
{
    public Item ToItem(
        Guid id,
        string name,
        string label,
        string type,
        string category,
        int model,
        int texture,
        int x,
        int y,
        int weight,
        int decayrate,
        string image,
        bool deg,
        bool fullyDegrades,
        bool nonStack,
        bool useable,
        bool unique,
        bool shouldClose,
        bool useRemove,
        string description)
    {
        return new Item(name, label, type, category, model, texture, x, y, weight, decayrate, image, deg, fullyDegrades, nonStack, useable, unique, shouldClose, useRemove, description)
        {
            Id = id
        };
    }
}
