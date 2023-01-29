using Domain.Items;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Items.Queries;

public class GetItemQueryByIdHandler : IRequestHandler<GetItemQuery, Item>
{
    private readonly IItemRepository _itemRepository;
    private readonly ILogger<GetItemQueryByIdHandler> _logger;

    public GetItemQueryByIdHandler(IItemRepository itemRepository,
        ILogger<GetItemQueryByIdHandler> logger)
    {
        _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(itemRepository));
    }
    public async Task<Item> Handle(GetItemQuery query, CancellationToken cancellationToken)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }
        var item = await _itemRepository.GetItemAsync(query.id, cancellationToken);
        return item;
    }
}