namespace Domain;
/// <summary>
/// Represents a business entity that contains a unique identifier and has an
/// state which can be stored in and retrieved from a persistent data store.
/// </summary>
/// <typeparam name="TId">
/// The type of value used to identify the entity.
/// </typeparam>
/// <typeparam name="TState">
/// The type that represents the state of the entity.
/// </typeparam>
public abstract class Entity<TId, TState>
{
    private readonly List<DomainEvent> _domainEvents = new();

    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public TId? Id { get; init; }

    /// <summary>
    /// Gets the collection of domain events that occurred over the lifetime of this instance.
    /// </summary>
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Gets the entity's current state.
    /// </summary>
    /// <remarks>
    /// The state can be used load a new instance of the entity.
    /// </remarks>
    public abstract TState GetState();

    /// <summary>
    /// Adds a new domain event to the current domain events collection for this instance.
    /// </summary>
    /// <param name="domainEvent">
    /// Required domain event to append to the list.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="domainEvent" /> is not provided.
    /// </exception>
    protected void AppendDomainEvent(DomainEvent domainEvent)
    {
        if (domainEvent == null)
        {
            throw new ArgumentNullException(nameof(domainEvent));
        }

        _domainEvents.Add(domainEvent);
    }
}
