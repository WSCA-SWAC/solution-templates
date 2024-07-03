using CSharpFunctionalExtensions;
using APPLICATION_NAME.Domain.Events;

namespace APPLICATION_NAME.Domain.Entities
{
    public class Order : AggregateRoot
    {
        private readonly List<OrderItem> _items;
        public DateTime OrderDate { get; private set; }
        public string Customer { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        private Order(string customer)
        {
            Customer = customer;
            OrderDate = DateTime.UtcNow;
            _items = new List<OrderItem>();
            AddDomainEvent(new OrderCreatedEvent(Id, Customer));
        }

        public static Result<Order> Create(string customer)
        {
            if (string.IsNullOrWhiteSpace(customer))
                return Result.Failure<Order>("Customer name is required.");

            return Result.Success(new Order(customer));
        }

        public Result AddItem(int productId, string productName, decimal unitPrice, int quantity)
        {
            var orderItemResult = OrderItem.Create(productId, productName, unitPrice, quantity);

            if (orderItemResult.IsFailure)
                return Result.Failure(orderItemResult.Error);

            _items.Add(orderItemResult.Value);
            AddDomainEvent(new OrderItemAddedEvent(Id, productId, productName));
            return Result.Success();
        }

        public decimal GetTotal()
        {
            return _items.Sum(item => item.UnitPrice * item.Quantity);
        }
    }
}
