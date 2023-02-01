namespace Domain.Items;

public class Item : Entity<Guid, ItemState>
{
    public Item(
        string name,
        string label,
        string type,
        string ammotype,
        string category,
        int? model,
        int? texture,
        int? x,
        int? y,
        int? weight,
        int? decayrate,
        string image,
        bool? deg,
        bool? fullyDegrades,
        bool? nonStack,
        bool? useable,
        bool? unique,
        bool? shouldClose,
        bool? useRemove,
        string description)
    {
        Name = name;
        Label = label;
        Type = type;
        Ammotype = ammotype;
        Category = category;
        Model = model;
        Texture = texture;
        Image = image;
        X = x;
        Y = y;
        Weight = weight;
        Decayrate = decayrate;
        FullyDegrades = fullyDegrades;
        Deg = deg;
        NonStack = nonStack;
        Useable = useable;
        Unique = unique;
        ShouldClose = shouldClose;
        UseRemove = useRemove;
        Description = description;
    }
    public string Name { get; set; }
    public string Label { get; set; }
    public string Type { get; set; }
    public string Ammotype { get; set; }
    public string Category { get; set; }
    public int? Model { get; set; }
    public int? Texture { get; set; }
    public int? X { get; set; }
    public int? Y { get; set; }
    public int? Weight { get; set; }
    public int? Decayrate { get; set; }
    public string Image { get; set; }
    public bool? Deg { get; set; }
    public bool? FullyDegrades { get; set; } = null;
    public bool? NonStack { get; set; }
    public bool? Useable { get; set; }
    public bool? ShouldClose { get; set; }
    public bool? Unique { get; set; }
    public bool? UseRemove { get; set; }
    public string Description { get; set; }

    public static Item Load(ItemState state)
    {
        return new Item(
            state.Name,
            state.Label,
            state.Type,
            state.Ammotype,
            state.Category,
            state.Model,
            state.Texture,
            state.X,
            state.Y,
            state.Weight,
            state.Decayrate,
            state.Image,
            state.Deg,
            state.FullyDegrades,
            state.NonStack,
            state.Useable,
            state.Unique,
            state.ShouldClose,
            state.UseRemove,
            state.Description)
        {
            Id = state.Id,
        };
    }

    public override ItemState GetState()
    {
        return new ItemState(
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
            Description);
    }
}
