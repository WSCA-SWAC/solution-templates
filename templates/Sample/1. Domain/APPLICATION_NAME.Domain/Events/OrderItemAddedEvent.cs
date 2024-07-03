using APPLICATION_NAME.Domain.Entities;

namespace APPLICATION_NAME.Domain.Events
{
    public class OrderItemAddedEvent : IDomainEvent
    {
        public int OrderId { get; }
        public int ProductId { get; }
        public string ProductName { get; }

        public OrderItemAddedEvent(int orderId, int productId, string productName)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
        }
    }
}
