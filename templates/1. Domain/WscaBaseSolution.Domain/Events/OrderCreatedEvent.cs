using WscaBaseSolution.Domain.Entities;

namespace WscaBaseSolution.Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get; }
        public string Customer { get; }

        public OrderCreatedEvent(int orderId, string customer)
        {
            OrderId = orderId;
            Customer = customer;
        }
    }
}
