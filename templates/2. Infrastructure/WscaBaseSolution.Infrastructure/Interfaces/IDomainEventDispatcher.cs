using WscaBaseSolution.Domain.Entities;

namespace WscaBaseSolution.Infrastructure.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
