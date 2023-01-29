using MassTransit;
using MediatR;
using Domain.Items;

namespace Application.Items.Queries;
public record GetItemQuery(
        Guid id) : IRequest<Item>;
