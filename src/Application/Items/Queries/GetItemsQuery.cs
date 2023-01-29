using MassTransit;
using MediatR;
using Domain.Items;

namespace Application.Items.Queries;
public record GetItemsQuery(
        string? name = default) : IRequest<IEnumerable<Item>>;
