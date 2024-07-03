using MediatR;
using APPLICATION_NAME.Domain.Events;

namespace APPLICATION_NAME.Application.EventHandlers
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the event (e.g., send an email, update a log, etc.)
            return Task.CompletedTask;
        }
    }
}
