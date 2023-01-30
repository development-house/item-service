using Domain.Items;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Items.Commands;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Item>
{
    private readonly IItemRepository _itemRepository;
    private readonly ILogger<UpdateItemCommandHandler> _logger;

    public UpdateItemCommandHandler(IItemRepository itemRepository, ILogger<UpdateItemCommandHandler> logger)
    {
        _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(itemRepository));
    }

    public async Task<Item> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        
    }
}
