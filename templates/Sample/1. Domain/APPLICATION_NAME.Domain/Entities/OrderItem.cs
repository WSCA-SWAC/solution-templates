using CSharpFunctionalExtensions;

namespace APPLICATION_NAME.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        private OrderItem(int productId, string productName, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public static Result<OrderItem> Create(int productId, string productName, decimal unitPrice, int quantity)
        {
            if (productId <= 0)
                return Result.Failure<OrderItem>("Product ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(productName))
                return Result.Failure<OrderItem>("Product name is required.");

            if (unitPrice <= 0)
                return Result.Failure<OrderItem>("Unit price must be greater than zero.");

            if (quantity <= 0)
                return Result.Failure<OrderItem>("Quantity must be greater than zero.");

            return Result.Success(new OrderItem(productId, productName, unitPrice, quantity));
        }
    }
}
