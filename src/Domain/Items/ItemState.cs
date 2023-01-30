namespace Domain.Items;
/// <summary>
/// Represents the current state of the item.
/// </summary>
/// <param name="name"></param>
/// <param name="label"></param>
/// <param name="type"></param>
/// <param name="category"></param>
/// <param name="model"></param>
/// <param name="texture"></param>
/// <param name="x"></param>
/// <param name="y"></param>
/// <param name="weight"></param>
/// <param name="decayrate"></param>
/// <param name="image"></param>
/// <param name="deg"></param>
/// <param name="fullyDegrades"></param>
/// <param name="nonStack"></param>
/// <param name="useable"></param>
/// <param name="unique"></param>
/// <param name="shouldClose"></param>
/// <param name="useRemove"></param>
/// <param name="description"></param>
public record struct ItemState(
    Guid Id,
    string Name,
    string Label,
    string Type,
    string Category,
    int? Model,
    int? Texture,
    int? X,
    int? Y,
    int? Weight,
    int? Decayrate,
    string Image,
    bool? Deg,
    bool? FullyDegrades,
    bool? NonStack,
    bool? Useable,
    bool? Unique,
    bool? ShouldClose,
    bool? UseRemove,
    string Description)
    {
        
    }
;
