using Domain.Items;

namespace Api.Items;
public record ItemResponse(
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
    public static ItemResponse Create(Item item)
    {
        return new(item.Id,
            item.Name,
            item.Label,
            item.Type,
            item.Category,
            item.Model,
            item.Texture,
            item.X,
            item.Y,
            item.Weight,
            item.Decayrate,
            item.Image,
            item.Deg,
            item.FullyDegrades,
            item.NonStack,
            item.Useable,
            item.Unique,
            item.ShouldClose,
            item.UseRemove,
            item.Description);
    }
}