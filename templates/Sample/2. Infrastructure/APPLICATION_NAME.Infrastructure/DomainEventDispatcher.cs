using MediatR;
using APPLICATION_NAME.Domain.Entities;
using APPLICATION_NAME.Infrastructure.Interfaces;

namespace APPLICATION_NAME.Infrastructure
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}
