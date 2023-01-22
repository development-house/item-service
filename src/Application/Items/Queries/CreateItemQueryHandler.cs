using Domain.Items;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Items.Commands;

public class CreateItemQueryHandler : IRequestHandler<CreateItemCommand, Item>
{
    private readonly IItemRepository _itemRepository;
    private readonly ILogger<CreateItemQueryHandler> _logger;

    public CreateItemQueryHandler(IItemRepository itemRepository,
        ILogger<CreateItemQueryHandler> logger)
    {
        _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(itemRepository));
    }
    public async Task<Item> Handle(CreateItemCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        var item = command.ToItem(command.name,
            command.label,
            command.type,
            command.category,
            command.model,
            command.texture,
            command.x,
            command.y,
            command.weight,
            command.decayrate,
            command.image,
            command.deg,
            command.fullyDegrades,
            command.nonStack,
            command.useable,
            command.unique,
            command.shouldClose,
            command.useRemove,
            command.description);
        item = await _itemRepository.CreateItem(item, cancellationToken);
        _logger.LogInformation("{ItemLabel} item created.", item.Label);
        return item;
    }
}