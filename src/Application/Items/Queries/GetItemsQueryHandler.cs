using Domain.Items;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Items.Queries;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<Item>>
{
    private readonly IItemRepository _itemRepository;
    private readonly ILogger<GetItemsQueryHandler> _logger;

    public GetItemsQueryHandler(IItemRepository itemRepository,
        ILogger<GetItemsQueryHandler> logger)
    {
        _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(itemRepository));
    }
    public async Task<IEnumerable<Item>> Handle(GetItemsQuery query, CancellationToken cancellationToken)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }
        var item = await _itemRepository.GetItemsAsync(query.name, cancellationToken);
        return item;
    }
}