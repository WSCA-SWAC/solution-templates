using APPLICATION_NAME.Domain.Entities;

namespace APPLICATION_NAME.Domain.Events
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
