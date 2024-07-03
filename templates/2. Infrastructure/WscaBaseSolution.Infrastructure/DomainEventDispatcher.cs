using MediatR;
using WscaBaseSolution.Domain.Entities;
using WscaBaseSolution.Infrastructure.Interfaces;

namespace WscaBaseSolution.Infrastructure
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
