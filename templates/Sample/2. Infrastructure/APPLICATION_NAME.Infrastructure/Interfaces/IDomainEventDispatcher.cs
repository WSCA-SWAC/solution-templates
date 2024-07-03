using APPLICATION_NAME.Domain.Entities;

namespace APPLICATION_NAME.Infrastructure.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
