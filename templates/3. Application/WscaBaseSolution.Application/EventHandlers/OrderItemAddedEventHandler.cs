using MediatR;
using WscaBaseSolution.Domain.Events;

namespace WscaBaseSolution.Application.EventHandlers
{
    public class OrderItemAddedEventHandler : INotificationHandler<OrderItemAddedEvent>
    {
        public Task Handle(OrderItemAddedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the event (e.g., update inventory, notify a service, etc.)
            return Task.CompletedTask;
        }
    }
}
