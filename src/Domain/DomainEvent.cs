using MediatR;

namespace Domain;
public abstract record DomainEvent : INotification;